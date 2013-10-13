using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuModel.BeatMapInfo
{
    /// <summary>
    /// 代表游戏模式
    /// </summary>
    public enum GameMode { OSU, Taiko, CTB, mania };
    /// <summary>
    /// 地图包，歌曲信息
    /// </summary>
    struct SongInfo
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
    /// StoryBoard的存储信息
    /// </summary>
    public struct StoryBoard
    {
        public enum ElementType { Sprite, Animation, Sample }
        public enum ElementLayer { Background, Fail, Pass, Foreground }
        public enum ElementOrigin { TopLeft, TopCenter, TopRight, CenterLeft, Center, CenterRight, BottomLeft, BottomCenter, BottomRight }
        public enum EventType
        {
            F,//fade【隐藏(淡入淡出)】
            M,//move【移动】
            S,//scale【缩放】
            V,//vector scale (width and height separately)【矢量缩放(宽高分别变动)】
            R,//rotate【旋转】
            C,//colour【颜色】
            L,//loop【循环】
            T,//Event-triggered loop【事件触发循环】
            P,//Parameters【参数】
        }
        public enum LoopType { LoopOnce, LoopForever }
        public enum TriggerType { HitSoundClap, HitSoundFinish, HitSoundWhistle, Passing, Failing }
        public struct SBEvent
        {
            public EventType Type;
            public int easing;
            //0 - none【没有缓冲】
            //1 - start fast and slow down【开始快结束慢】
            //2 - start slow and speed up【开始慢结束快】
            public uint StartT, EndT;
            public float startxF, startyF, endyF, endxF;//F,S(只用x),V 'F stands for float-option
            public System.Drawing.Point StartP,EndP;//R(只用x),MX,MY（只用x/y),M
            //注意P还没写 H - 水平翻转 V - 垂直翻转 A - additive-blend colour (as opposed to alpha-blend)
            public System.Drawing.Color Color1, Color2;//C
        }
        public class SBElement
        {
            public ElementType Type;
            public ElementLayer Layers;
            public ElementOrigin Origin;
            public string Path;
            public System.Drawing.Point p;
            public int FrameCount, FrameDelay;
            public LoopType Looptype;
            public int Time, Volume;
            public SBEvent[] SBEvents;

        }
    }
}
