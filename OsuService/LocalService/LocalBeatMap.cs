using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LocalService
{
    /// <summary>
    /// 本地BeatMap基本操作类
    /// </summary>
    public class LocalBeatMap
    {
        List<DirectoryInfo> beatMapDirs1;

        /// <summary>
        /// 获取符合筛选条件的目录信息
        /// 如果遍历的目录存在 Filter 筛选成功的文件，就返回该目录并结束该节点的遍历。
        /// </summary>
        /// <param name="pPath">要遍历的目录</param>
        /// <param name="pFilter">文件筛选器</param>
        /// <returns>结果列表</returns>
        public List<DirectoryInfo> GetBeatMapDirs(string pPath, string pFilter)
        {
            this.beatMapDirs1 = new List<DirectoryInfo>();
            this.SubOsuDir(pPath, pFilter);

            return beatMapDirs1;
        }



        /// <summary>
        /// 递归方式，获取存在给定 筛选文件 的目录
        /// 只要目录内存在指定 筛选器 的文件，就结束该节点的遍历，提高性能
        /// </summary>
        /// <param name="pPath">要遍历的目录</param>
        /// <param name="pFilter">筛选字符串</param>
        private void SubOsuDir(string pPath, string pFilter)
        {
            DirectoryInfo dir = new DirectoryInfo(pPath);
            if (!dir.Exists)
            {
                return;  //该目录异常，退出
            }

            FileInfo[] f1s = dir.GetFiles(pFilter);  //获取该节点的文件
            if (f1s.Length > 0)  //存在osu文件
            {
                beatMapDirs1.Add(dir);  //该目录被识别为BeatMap目录              
                return; //不再遍历此目录的子目录
            }

            DirectoryInfo[] d1s = dir.GetDirectories();  //获取本目录存在的子目录列表

            for (int i = 0; i < d1s.Length; i++)
            {
                SubOsuDir(d1s[i].FullName, pFilter);  //递归子目录
            }
        }
    }
}


