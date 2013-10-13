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
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

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

            //这儿好像是简单的“控制反转”，暂时不理解，（类似于中介公司）
            SimpleIoc.Default.Register<MainVM>();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels（销毁模型对象）
        }


        public MainVM Main
        {
            get { return ServiceLocator.Current.GetInstance<MainVM>(); }
        }


    }
}
