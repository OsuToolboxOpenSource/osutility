using GalaSoft.MvvmLight;
using OsuModel.BeatMap;

namespace Osutility_Beta.ViewModel.ChildVM
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BeatMapItemViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the BeatMapItemViewModel class.
        /// </summary>
        public BeatMapItemViewModel()
        {
            this.BeatMap = new BeatMapBase();
        }

        private BeatMapBase _BeatMap;
        /// <summary>
        /// 一个简单歌曲包
        /// </summary>
        public BeatMapBase BeatMap
        {
            get { return _BeatMap; }
            set
            {
                _BeatMap = value;
                this.RaisePropertyChanged("BeatMap");
            }
        }

        private BeatMap_OsuApi _BeatMapOsuApi;

        public BeatMap_OsuApi BeatMapOsuApi
        {
            get { return _BeatMapOsuApi; }
            set
            {             
                _BeatMapOsuApi = value;
                this.RaisePropertyChanged("BeatMapOsuApi");
            }
        }

        
    }
}