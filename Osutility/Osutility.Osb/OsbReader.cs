using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Osutility.Osb
{
    /// <summary>
    /// 以 osb 文件形式读取内容
    /// </summary>
    public class OsbReader : IOsbReader
    {
        /// <summary>
        /// 指定一个文件，用于接下来的内容读取
        /// </summary>
        /// <param name="filePath">osb格式文件路径</param>
        public OsbReader(string filePath)
        {
            _FilePath = filePath;
        }

        /// <summary>
        /// 操作文件路径
        /// </summary>
        private readonly string _FilePath;

        public IList<OsbInfo> ReadAll()
        {
            var result = new List<OsbInfo>();

            using (TextReader sr = new StringReader(_FilePath))
            using (IOsbParser srp = new OsbParser(sr))
            {
                if (!srp.SeekSection())
                {
                    throw new OsbReaderException("No section [Events] was found");
                }

                OsbInfo model;
                while (srp.TryReadBlock(out model))
                {
                    result.Add(model);
                }
            }
            return result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
