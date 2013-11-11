using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Osutility_Beta.ViewModel.ChildVM;
using System.Collections.Generic;
using Osutility_Beta.Service.ServiceFactory;
using OsuModel.BeatMap;

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

        DataFactory zDataFactory = new DataFactory();


        
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




        private RelayCommand _GetLocalBeatMapListing;
        /// <summary>
        /// 获取本地存储的BeatMapListing
        /// </summary>
        public RelayCommand GetLocalBeatMapListing
        {
            get
            {
                return _GetLocalBeatMapListing
                    ?? (_GetLocalBeatMapListing = new RelayCommand(
                                          () =>
                                          {
                                              Ex_GetLocalBeatMapListing();
                                          }));
            }
        }

        private RelayCommand _GetOsuApiBeatMapListing;

        /// <summary>
        /// 由 osu-api 获取BeatMapListing
        /// </summary>
        public RelayCommand GetOsuApiBeatMapListing
        {
            get
            {
                return _GetOsuApiBeatMapListing
                    ?? (_GetOsuApiBeatMapListing = new RelayCommand(
                                          () =>
                                          {
                                              ExGetOsuApiBeatMapListing();
                                          }));
            }
        }
















        private void ExGetOsuApiBeatMapListing()
        {
            
        }


        /// <summary>
        /// 填充BeatMapListing
        /// </summary>
        private void Ex_GetLocalBeatMapListing()
        {
            List<BeatMapBase> beatMap_s1 = zDataFactory.GetLocalBeatMapListingByDirListing(Osutility_Beta.Properties.Settings.Default.osuDirectory, "*.osu");

            var beatMapListing1 = new List<BeatMapItemViewModel>();  //准备填充显示列表
            BeatMapItemViewModel beatMapItemVM1;  //列表里的某一项

            foreach (var i in beatMap_s1) //遍历获取到的
            {
                beatMapItemVM1 = new BeatMapItemViewModel();
                beatMapItemVM1.BeatMap = i;

                //其他需要往界面填充值的
                //值

                beatMapListing1.Add(beatMapItemVM1);
            }

            this.BeatMapListing = beatMapListing1;  //将最终结果传递回界面
        }
    }
}