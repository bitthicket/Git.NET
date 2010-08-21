using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using ComponentAce.Compression.Libs.zlib;
using NLog;

namespace Git
{
    public abstract class Object : IObject, IDisposable
    {
        private const int MaxHeaderLength = 64;
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
                    blob.m_Digest = digest;
                    blob.m_Type = ObjectType.Blob;
                    blob.m_Size = Convert.ToUInt64(header[1]);
                    result = blob;
                    break;
                case "tree":
                    var tree = new Tree();
                    tree.m_Digest = digest;
                    tree.m_Type = ObjectType.Tree;
                    tree.m_Size = Convert.ToUInt64(header[1]);
                    result = tree;
                    break;
                case "commit":
                    var commit = new Commit();
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

        public static IObject CreateObject(string repoPath, byte[] digest)
        {
            string dir = Encoding.ASCII.GetString(digest, 0, 2);
            string leaf = Encoding.ASCII.GetString(digest, 2, digest.Length - 3);

            return CreateObject(Path.Combine(repoPath, dir, leaf));
        }

        #region IObject Members

        public byte[] Digest
        {
            // TODO need a method to validate?  For now, just set from the filename.
            get { throw new NotImplementedException(); }
        }

        public ObjectType Type
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ulong Size
        {
            get { throw new NotImplementedException(); }
        }

        public void Deflate(string outputPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
