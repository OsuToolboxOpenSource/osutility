using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuModel.BeatMap
{
    /// <summary>
    /// 地图包，歌曲信息
    /// </summary>
    public class SongInfo
    {
        //prop代码段生成
        //敲入prop后，按“Tab”键生成

        /// <summary>
        /// 歌曲标题
        /// </summary>
        public string Title;

        /// <summary>
        /// 本歌演唱者
        /// </summary>
        public string Artist;

        /// <summary>
        /// BeatMap作者
        /// </summary>
        public string Creator;

        /// <summary>
        /// 难度；在osu文件里表示为Version
        /// </summary>
        public string Difficulty;

        /// <summary>
        /// 歌曲来源
        /// </summary>
        public string Source;

        /// <summary>
        /// 歌曲搜索参数
        /// </summary>
        public string Tags;

        /// <summary>
        /// 音乐文件名
        /// </summary>
        public string AudioFileName;

        /// <summary>
        /// 音乐文件起始时间
        /// </summary>
        public int AudioLeadIn;

        /// <summary>
        /// 前奏时间
        /// </summary>
        public int PreviewTime;

        /// <summary>
        /// 是否有倒数
        /// </summary>
        public bool CountDown;

        /// <summary>
        /// 所用音效的SampleSet
        /// </summary>
        public string SampleSet;

        /// <summary>
        /// Note的重叠程度
        /// </summary>
        public decimal StackLeniecy;

        /// <summary>
        /// 游戏模式
        /// </summary>
        public GameMode Mode;

        /// <summary>
        /// 休息时是否出现提示
        /// </summary>
        public bool LetterBoxInBreaks;

        /// <summary>
        /// 允许宽屏下的StoryBoard；发现于file format v12
        /// </summary>
        public bool WideScreenStoryBoard;

        /// <summary>
        /// 编辑器：Note间距
        /// </summary>
        public float DistanceSpacing;

        /// <summary>
        /// 编辑器：分拍率
        /// </summary>
        public int BeatDivisor;

        /// <summary>
        /// 编辑器：网格大小
        /// </summary>
        public int GridSize;

        /// <summary>
        /// HPDrainRate
        /// </summary>
        public int HP;

        /// <summary>
        /// CircleSize
        /// </summary>
        public int CS;

        /// <summary>
        /// OverAllDifficulty
        /// </summary>
        public int OD;

        /// <summary>
        /// ApproachingRate
        /// </summary>
        public int AR;

        /// <summary>
        /// SliderMultiplier
        /// </summary>
        public int SM;

        /// <summary>
        /// SliderTickRate
        /// </summary>
        public int STR;


    }//未完成

    /// <summary>
    /// 代表游戏模式
    /// </summary>
    public enum GameMode
    {
        OSU,
        Taiko,
        CTB,
        mania
    };
}
