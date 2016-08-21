using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osutility.Osb
{
    /// <summary>
    /// 支持osb文档块解析
    /// </summary>
    public interface IOsbParser : IDisposable
    {
        /// <summary>
        /// 查找并定位到节的开始位置（跳过节标签）
        /// </summary>
        /// <returns>是否成功查找并定位</returns>
        bool SeekSection();
        /// <summary>
        /// 获取下一个可解析的osb块（Sprite or Animation），返回是否是否结束至结尾或无法继续解析
        /// </summary>
        /// <returns>true：可解析为osb块，otherwise false</returns>
        bool TryReadBlock(out OsbInfo block);
    }
}
