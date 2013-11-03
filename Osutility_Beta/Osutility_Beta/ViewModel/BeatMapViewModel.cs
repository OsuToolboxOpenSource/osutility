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
            List<BeatMapInfo> beatMap_s1 = zDataFactory.GetBeatMapListingByDirListing(@"E:\NetGame\osu!\Songs", "*.osu");

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