using OsuService.LocalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OsuModel.BeatMap;
using OsuService.NetService;

namespace Osutility_Beta.Service.ServiceFactory
{
    /// <summary>
    /// 界面模型与Service空间交互逻辑
    /// 由目录列表获取BeatMap列表。
    /// </summary>
    class DataFactory
    {
        LibLocalService zLibLocalService = new LibLocalService();
        LibNetService zNetService = new LibNetService();

        /// <summary>
        /// 由目录列表获取BeatMap信息列表。
        /// </summary>
        /// <param name="pPath">要遍历的目录</param>
        /// <param name="pFilter">文件筛选通配符</param>
        public List<BeatMapBase> GetLocalBeatMapListingByDirListing(string pPath, string pFilter)
        {
            List<BeatMapBase> beatMapListing1 = new List<BeatMapBase>();  //要返回的列表
            BeatMapBase beatmap1;  //临时填充

            //获取到存在osu文件的目录，并传入模型
            List<DirectoryInfo> dirs = zLibLocalService.LocalBeatMap().GetBeatMapDirs(pPath, pFilter);
            foreach (var i in dirs)
            {
                beatmap1 = new BeatMapBase();
                beatmap1.Title = i.Name;

                //此处暂时只获取一个内容，就是目录名称（多数都是BeatMap的名）
                //获取本目录里
                //其他有关信息（如本BeatMap的文件与目录，或者读取单文件（复杂读取））

                beatMapListing1.Add(beatmap1);  //加入返回列表
            }


            return beatMapListing1;
        }

        public List<BeatMap_OsuApi> GetOsuApiBeatMapListingByWeb()
        {
            List<BeatMap_OsuApi> beatMapListring1 = new List<BeatMap_OsuApi>();

            string jsonString1=
            zLibLocalService.JsonSerializerCore().Deserialize(

            return beatMapListring1;
        }
    }
}
