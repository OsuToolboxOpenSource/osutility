using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OsuModel.BeatMapFile
{
    /// <summary>
    /// 代表一个BeatMapSet
    /// </summary>
    public class BeatMapSet
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        BeatMapSet()
        {

        }

        /// <summary>
        /// 整首曲子所在文件夹
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// BeatMapSet的ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 读取指定的路径
        /// </summary>
        /// <param name="path">BeatMapSet所在路径</param>
        BeatMapSet(string path)
        {
            Load(path);
        }
        /// <summary>
        /// 读取指定的路径
        /// </summary>
        /// <param name="path">BeatMapSet所在路径</param>
        public void Load(string path)
        {
            DirectoryInfo BMSDir = new DirectoryInfo(path);
            if (!BMSDir.Exists) return;
            Path = BMSDir.FullName;
            ID = int.Parse(BMSDir.Name.Split(' ')[0]);
            FileInfo[] OSUFiles = BMSDir.GetFiles("*.osu");
            Difficulties = new System.Collections.Generic.List<OSUFile>();

            foreach (FileInfo Info in OSUFiles)
            {
                Difficulties.Add(new OSUFile(this, Info.FullName));
            }

            OSUFiles = BMSDir.GetFiles("*.osb");

            if (OSUFiles.Length > 0)
            {
                StoryBoard = new OSBFile(this, OSUFiles[0].FullName);
            }
        }//皮肤未实现

        public System.Collections.Generic.List<OSUFile> Difficulties;
        public OSBFile StoryBoard;
    }
    
    //未完成
    /// <summary>
    /// 表示osu文件
    /// </summary>
    public class OSUFile
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public OSUFile() { }

        /// <summary>
        /// osu文件路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// BeatMap ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 返回所在的BeatMapSet
        /// </summary>
        public BeatMapSet MapSet { get; set; }
        /// <summary>
        /// 整个BeatMap的信息
        /// </summary>
        public BeatMap.SongInfo SongInfo { get; set; }
        /// <summary>
        /// osu文件内嵌SB的信息
        /// </summary>
        public StoryBoard.StoryBoardInfo SBInfo { get; set; }

        /// <summary>
        /// 给定BeatMapSet与路径读取文件：一般仅供BeatMapSet调用
        /// </summary>
        /// <param name="BMS">BeatMapSet</param>
        /// <param name="path">文件完整路径</param>
        public OSUFile(BeatMapSet BMS, string path)
        {
            Load(BMS, path);
        }
        /// <summary>
        /// 给定BeatMapSet与路径读取文件：很少使用
        /// </summary>
        /// <param name="BMS">BeatMapSet</param>
        /// <param name="path">文件完整路径</param>
        public void Load(BeatMapSet BMS, string path)
        {
            MapSet = BMS;
            Path = path;

        }//未完成

    }//未完成
    /// <summary>
    /// 表示osb文件
    /// </summary>
    public class OSBFile
    {
        /// <summary>
        /// osu文件路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 返回所在的BeatMapSet
        /// </summary>
        public BeatMapSet MapSet { get; set; }
        /// <summary>
        /// 存储在osb文件里的SB信息
        /// </summary>
        public StoryBoard.StoryBoardInfo SBInfo;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public OSBFile() { }
        /// <summary>
        /// 给定BeatMapSet与路径读取文件：一般仅供BeatMapSet调用
        /// </summary>
        /// <param name="BMS">BeatMapSet</param>
        /// <param name="path">文件完整路径</param>
        public OSBFile(BeatMapSet BMS, string path) { Load(BMS, path); }
        /// <summary>
        /// 给定BeatMapSet与路径读取文件：很少使用
        /// </summary>
        /// <param name="BMS">BeatMapSet</param>
        /// <param name="path">文件完整路径</param>
        public void Load(BeatMapSet BMS, string path)
        {
            MapSet = BMS;
            Path = path;

        }//未完成

    }//未完成

}
