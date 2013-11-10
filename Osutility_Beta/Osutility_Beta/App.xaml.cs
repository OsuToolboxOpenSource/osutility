using GalaSoft.MvvmLight.Threading;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Osutility_Beta
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //MvvmLight的线程
            DispatcherHelper.Initialize();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //保存程序配置文件
            Osutility_Beta.Properties.Settings.Default.Save();
        }
    }
}
