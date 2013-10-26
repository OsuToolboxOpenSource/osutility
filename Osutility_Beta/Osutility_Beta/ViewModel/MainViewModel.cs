using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Osutility_Beta.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 初始化源
        /// </summary>
        public MainViewModel()
        {

        }

        /// <summary>
        /// 回收源
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
        }

        #region 绑定成员DP

        #endregion

        #region 命令Command
       

        private RelayCommand _ShowBeatMapWindow;

        /// <summary>
        /// Gets the ShowBeatMapWindow.
        /// </summary>
        public RelayCommand ShowBeatMapWindow
        {
            get
            {
                return _ShowBeatMapWindow
                    ?? (_ShowBeatMapWindow = new RelayCommand(
                                          () =>
                                          {
                                              Ex_ShowBeatMapWindow();
                                          }));
            }
        }


        #endregion

        #region 命令方法Ex
     

        private void Ex_ShowBeatMapWindow()
        {
            new Osutility_Beta.View.BeatMapView().Show();
        }
        #endregion

        #region 普通方法Method

        #endregion

    }
}
