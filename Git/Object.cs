using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using Microsoft.Win32;

using ComponentAce.Compression.Libs.zlib;
using NLog;

namespace Git
{
    public abstract class Object : IObject, IDisposable
    {
        private const int MaxHeaderLength = 64;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private string m_Path;
        private byte[] m_Digest;
        private ObjectType m_Type;
        private ulong m_Size;

        protected Object() {}

        public static IObject CreateObject(string path)
        {
            logger.Trace("creating new Object from path {0}", path);            

            string digestString = Path.GetFileName(Path.GetDirectoryName(path)) + Path.GetFileName(path);
            logger.Trace("filename indicates digest of: {0}", digestString);
            byte[] digest = Encoding.ASCII.GetBytes(digestString.ToCharArray());

            byte[] buffer = new byte[MaxHeaderLength];
            using (ZInputStream zInput = new ZInputStream(File.Open(path, FileMode.Open, FileAccess.Read)))
            {
                logger.Trace("reading {0} bytes", MaxHeaderLength);
                zInput.Read(buffer, 0, MaxHeaderLength);
            }

            string[] header = null;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0)
                {
                    header = new String(Encoding.ASCII.GetChars(buffer, 0, i)).Split(' ');
                    break;
                }   
            }

            logger.Trace("got header: {0} {1}", header[0], header[1]);           

            logger.Debug("got object of type {0}", header[0]);
            // TODO use header to create appropriate object
            IObject result = null;
            switch (header[0])
            {
                case "blob":
                    var blob = new Blob();
                    blob.m_Path = path;
                    blob.m_Digest = digest;
                    blob.m_Type = ObjectType.Blob;
                    blob.m_Size = Convert.ToUInt64(header[1]);
                    result = blob;
                    break;
                case "tree":
                    var tree = new Tree();
                    tree.m_Path = path;
                    tree.m_Digest = digest;
                    tree.m_Type = ObjectType.Tree;
                    tree.m_Size = Convert.ToUInt64(header[1]);
                    result = tree;
                    break;
                case "commit":
                    var commit = new Commit();
                    commit.m_Path = path;
                    commit.m_Digest = digest;
                    commit.m_Type = ObjectType.Commit;
                    commit.m_Size = Convert.ToUInt64(header[1]);
                    result = commit;
                    break;
                case "tag":
                    break;
                default:
                    break;
            }                        
   
            return result;
        }

        // TODO this will need to support pack files as well
        public static IObject CreateObject(string repoPath, byte[] digest)
        {
            logger.Trace("Opening object {0} in repository {1}", Convert.ToString(digest), repoPath);
            string dir = BitConverter.ToString(digest, 0, 1).Replace("-","").ToLowerInvariant();
            string leaf = BitConverter.ToString(digest, 1).Replace("-","").ToLowerInvariant();

            logger.Trace("Opening object file at {0}/{1}/{2}", repoPath, dir, leaf);
            return CreateObject(Path.Combine(repoPath, "objects", dir, leaf));
        }        

        public static byte[] DigestFromString(string digest)
        {
            if (digest.Length != 40)
            {
                return null;
            }

            byte[] result = new byte[20];
            for (int i = 0, j = 0; i < digest.Length; i=i+2,j++)
            {
                result[j] = Byte.Parse(digest.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        public static string StringFromDigest(byte[] digest)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in digest)
            {
                sb.Append(Convert.ToString(b));
            }

            string result = sb.ToString();
            logger.Trace("Converted digest to {0}", result);
            return result;
        }

        #region IObject Members

        public byte[] Digest
        {
            // TODO need a method to validate?  For now, just set from the filename.
            get { return m_Digest; }
        }

        public ObjectType Type
        {
            get
            {
                return m_Type;
            }           
        }

        public ulong Size
        {
            get { return m_Size; }
        }

        public void Deflate(string outputPath)
        {
            using (ZInputStream zInput = new ZInputStream(File.Open(m_Path, FileMode.Open, FileAccess.Read)))
            {
                int maxBlockSize;
                logger.Trace("Opening registry key to find MaxBlockSize");
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Bit Thicket\\Git\\Streams");
                try
                {
                    maxBlockSize = Convert.ToInt32(key.GetValue("MaxBlockSize"));
                }
                catch (Exception e)
                {
                    logger.LogException(LogLevel.Info, "MaxBlockSize not specified.  Using default of 4k", e);
                    maxBlockSize = 4096;
                }

                using (var t0 = new TransferStream(File.Open(outputPath, FileMode.Create, FileAccess.Write)))
                {
                    byte[] buffer = new byte[maxBlockSize];
                    int readCount = 0;
                    // TODO: why isn't this reading a whole block?
                    while (maxBlockSize == (readCount = zInput.Read(buffer, 0, maxBlockSize)))
                    {
                        logger.Trace("read {0} bytes", readCount);
                        t0.Write(buffer, 0, readCount);
                    }
                    logger.Trace("writing final block of {0} bytes", readCount);
                    t0.Write(buffer, 0, readCount);
                }
            }
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
