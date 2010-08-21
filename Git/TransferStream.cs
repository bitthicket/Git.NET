using System;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Git
{
    class TransferStream : Stream
    {
        private Stream m_WriteableStream;
        private BlockingCollection<byte[]> m_Blocks;
        private Task m_ProcessingTask;

        public TransferStream(Stream writeableStream)
        {
            // TODO validate arguments
            m_WriteableStream = writeableStream;
            m_Blocks = new BlockingCollection<byte[]>();
            m_ProcessingTask = Task.Factory.StartNew(() =>
                {
                    foreach (var block in m_Blocks.GetConsumingEnumerable())
                    {
                        m_WriteableStream.Write(block, 0, block.Length);
                    }
                }, TaskCreationOptions.PreferFairness);
        }

        public override bool CanWrite
        {
            // TODO: check state of output stream
            get { return true; }
        }       

        public override void Write(byte[] buffer, int offset, int count)
        {
            var block = new byte[count];
            Buffer.BlockCopy(buffer, offset, block, 0, count);
            m_Blocks.Add(block);
        }

        public override void Close()
        {
            m_Blocks.CompleteAdding();
            try { m_ProcessingTask.Wait(); }
            finally { base.Close(); }
        }

        public override bool CanRead
        {
            get { throw new NotImplementedException(); }
        }

        public override bool CanSeek
        {
            get { throw new NotImplementedException(); }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
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

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
    }
}
