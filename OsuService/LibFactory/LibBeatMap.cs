using LocalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibFactory
{
    /// <summary>
    /// 这是一个类工厂，用于公开所有Service逻辑，与界面交互的唯一通道
    /// </summary>
    public class LibBeatMap
    {
        public LocalBeatMap LocalBeatMap()
        {
            return new LocalBeatMap();
        }


    }
}
