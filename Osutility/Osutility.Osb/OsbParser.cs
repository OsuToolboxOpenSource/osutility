using System;
using System.IO;

namespace Osutility.Osb
{
    /// <summary>
    /// 读取osb文档块，用于解析功能
    /// </summary>
    public class OsbParser : IOsbParser
    {
        public OsbParser(TextReader textReader)
        {
            this.reader = textReader;
        }

        /// <summary>
        /// 节标识，一般用中括号表示
        /// </summary>
        protected const string HEADER = "[Events]";
        private TextReader reader;

        public bool SeekSection()
        {
            bool result = false;

            string line;
            while (-1 != reader.Peek())
            {
                // have next char
                line = reader.ReadLine();
                if (line.StartsWith(HEADER))
                {
                    // match [Events] section
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool TryReadBlock(out OsbInfo block)
        {
            throw new NotImplementedException();
        }

        #region 接口：IDisposable

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) { return; }

            if (disposing)
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }

            disposed = true;
            reader = null;
        }

        /// <summary>
        /// Checks if the instance has been disposed of.
        /// </summary>
        /// <exception cref="ObjectDisposedException" />
        protected virtual void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().ToString());
            }
        }

        #endregion 接口：IDisposable
    }
}