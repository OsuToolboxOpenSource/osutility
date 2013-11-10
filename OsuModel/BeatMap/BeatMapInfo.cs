using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OsuModel.BeatMap
{
    /// <summary>
    /// BeatMap的基类
    /// </summary>
    public class BeatMapBase
    {
        public BeatMapBase(int beatmapset_id = 0, string title = "", string artist = "")
        {
            this.Beatmapset_id = beatmapset_id;
            this.Title = title;
            this.Artist = artist;
        }

        /// <summary>
        /// Id
        /// beatmapset_id groups difficulties into a set
        /// </summary>
        public int Beatmapset_id { get; set; }
        /// <summary>
        /// Map标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Map艺术家
        /// </summary>
        public string Artist { get; set; }
    }

    /// <summary>
    /// 根据官网的api返回的BeatMap
    /// </summary>
    public class BeatMap_OsuApi : BeatMapBase
    {
        /// <summary>
        /// 2 = approved, 1 = ranked, 0 = pending, -1 = WIP, -2 = graveyard
        /// </summary>
        public string Approved { get; set; }
        /// <summary>
        ///  date ranked, UTC+8 for now
        /// </summary>
        public string Approved_date { get; set; }
        /// <summary>
        /// last update date, timezone same as above. 
        /// May be after approved_date if map was unranked and reranked.
        /// </summary>
        public string Last_update { get; set; }  
        /// <summary>
        /// beatmap_id is per difficulty
        /// </summary>
        public string Beatmap_id { get; set; }       
        /// <summary>
        /// 
        /// </summary>
        public string Bpm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// out of a possible 5
        /// </summary>
        public string Difficultyrating { get; set; }
        /// <summary>
        /// seconds from first note to last note not including breaks
        /// </summary>
        public string Hit_length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }    
        /// <summary>
        /// seconds from first note to last note including breaks
        /// </summary>
        public string Total_length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// game mode
        /// </summary>
        public string Mode { get; set; }
    }

}
