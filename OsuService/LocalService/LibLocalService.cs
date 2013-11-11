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
        public LocalBeatMapCore LocalBeatMap()
        {
            return new LocalBeatMapCore();
        }

        /// <summary>
        /// Json转列表器
        /// </summary>
        /// <returns></returns>
        public JsonSerializerCore JsonSerializerCore()
        {
            return new JsonSerializerCore();
        }
    }
}
