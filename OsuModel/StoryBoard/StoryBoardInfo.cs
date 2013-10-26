using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuModel.StoryBoard
{

    public class StoryBoardInfo
    {
        public SBEvent SbEvent { get; set; }
        public SBElement SbElement { get; set; }

    }



    public class SBEvent
    {
        public EventType Type;
        public int easing;
        //0 - none【没有缓冲】
        //1 - start fast and slow down【开始快结束慢】
        //2 - start slow and speed up【开始慢结束快】
        public uint StartT, EndT;
        public float startxF, startyF, endyF, endxF;//F,S(只用x),V 'F stands for float-option
        public System.Drawing.Point StartP, EndP;//R(只用x),MX,MY（只用x/y),M
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

    public enum ElementType
    {
        Sprite,
        Animation,
        Sample
    }
    public enum ElementLayer
    {
        Background,
        Fail,
        Pass,
        Foreground
    }
    public enum ElementOrigin
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
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
    public enum LoopType
    {
        LoopOnce,
        LoopForever
    }
    public enum TriggerType
    {
        HitSoundClap,
        HitSoundFinish,
        HitSoundWhistle,
        Passing,
        Failing
    }

}
