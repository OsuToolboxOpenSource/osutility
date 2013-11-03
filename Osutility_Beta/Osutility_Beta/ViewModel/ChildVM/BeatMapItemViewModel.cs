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
            this.BeatMap = new BeatMapInfo();
        }

        private BeatMapInfo _BeatMap;
        /// <summary>
        /// 一个歌曲包
        /// </summary>
        public BeatMapInfo BeatMap
        {
            get { return _BeatMap; }
            set
            {
                _BeatMap = value;
                this.RaisePropertyChanged("BeatMap");
            }
        }


    }
}