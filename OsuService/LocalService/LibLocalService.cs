using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuService.LocalService
{
    public class LibLocalService
    {
        /// <summary>
        /// BeatMap本地交互逻辑
        /// </summary>
        /// <returns></returns>
        public LocalBeatMap LocalBeatMap()
        {
            return new LocalBeatMap();
        }
    }
}
