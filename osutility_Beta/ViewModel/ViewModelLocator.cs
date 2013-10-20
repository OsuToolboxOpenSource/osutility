using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace osutility_Beta.ViewModel
{
    /// <summary>
    /// vm模型容器
    /// </summary>
    class ViewModelLocator
    {
        /// <summary>
        /// ViewModelLocator 初始化构造函数.
        /// </summary>
        public ViewModelLocator()
        {
            #region DesignMode设计时（未使用）
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // 创建设计时视图服务模型
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // 创建运行时视图服务模型
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            #endregion

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            Creat_Main();
            Creat_BeatMap();
            Creat_Test();
        }


        #region Creat_创建对象

        private void Creat_Main()
        {
            //这儿好像是简单的“控制反转”，暂时不理解，（类似于中介公司）
            SimpleIoc.Default.Register<MainViewModel>();
        }
        private void Creat_BeatMap()
        {
            SimpleIoc.Default.Register<BeatMapViewModel>();
        }
        private void Creat_Test()
        {
            SimpleIoc.Default.Register<TestViewModel>();
        }

        #endregion

        #region CleanUp销毁对象
        public static void CleanupAll()
        {
            // TODO Clear the ViewModels（销毁模型对象）
            CleanMain();
            CleanBeatMap();
        }

        private static void CleanBeatMap()
        {
            SimpleIoc.Default.Unregister<BeatMapViewModel>();
        }

        private static void CleanMain()
        {
            SimpleIoc.Default.Unregister<MainViewModel>();
        }
        #endregion

        #region vm_对象

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the BeatMapViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This non-static member is needed for data binding purposes.")]
        public BeatMapViewModel BeatMapVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BeatMapViewModel>();
            }
        }

        /// <summary>
        /// Gets the TestVM property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public TestViewModel TestVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TestViewModel>();
            }
        }
        #endregion

    }
}
