using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Osutility_Beta.ViewModel.ChildVM;
using System.Collections.Generic;
using OsuService.LocalService;

namespace Osutility_Beta.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BeatMapViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the BeatMapViewModel class.
        /// </summary>
        public BeatMapViewModel()
        {
            
        }

        LibLocalService zLibLocalService = new LibLocalService();  //本地处理逻辑
        



        private List<BeatMapItemViewModel> _BeatMapListing;
        /// <summary>
        /// BeatMap列表
        /// </summary>
        public List<BeatMapItemViewModel> BeatMapListing
        {
            get { return _BeatMapListing; }
            set
            {
                _BeatMapListing = value;
                this.RaisePropertyChanged("BeatMapListing");
            }
        }

        


        private RelayCommand _GetBeatMapListing;

        /// <summary>
        /// Gets the GetBeatMapListing.
        /// </summary>
        public RelayCommand GetBeatMapListing
        {
            get
            {
                return _GetBeatMapListing
                    ?? (_GetBeatMapListing = new RelayCommand(
                                          () =>
                                          {
                                              Ex_GetBeatMapListing();
                                          }));
            }
        }



        /// <summary>
        /// 填充BeatMapListing
        /// </summary>
        private void Ex_GetBeatMapListing()
        {
            zLibLocalService.LocalBeatMap().GetBeatMapDirs(@"E:\NetGame\osu!\Songs", "*.osu");
        }
    }
}