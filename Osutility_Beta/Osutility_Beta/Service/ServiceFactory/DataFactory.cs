using OsuService.LocalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OsuModel.BeatMap;

namespace Osutility_Beta.Service.ServiceFactory
{
    /// <summary>
    /// 界面模型与Service空间交互逻辑
    /// 由目录列表获取BeatMap列表。
    /// </summary>
    class DataFactory
    {
        LibLocalService zLibLocalService = new LibLocalService();

        /// <summary>
        /// 由目录列表获取BeatMap列表。
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pFilter"></param>
        public void GetBeatMapListingByDirListing(string pPath, string pFilter)
        {
            List<BeatMapInfo> beatMapListing1=new List<BeatMapInfo>();  //要返回的列表
           BeatMapInfo beatmap1;  //临时填充

            List<DirectoryInfo> dirs = zLibLocalService.LocalBeatMap().GetBeatMapDirs(pPath, pFilter);
                      foreach (var i in dirs)
            {
                beatmap1=new BeatMapInfo();
                beatmap1.Title = i.FullName;
            }
        }
    }
}
