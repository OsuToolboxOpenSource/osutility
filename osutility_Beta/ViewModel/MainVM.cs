using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace osutility_Beta.ViewModel
{
    class MainVM:ObservableObject
    {
        public MainVM()
        {
            //初始化源
            this.ShowMessage = "数据模型加载";
        }

        /// <summary>
        /// 与界面交互的数据模型
        /// </summary>
        #region 自动更新属性 Prop

         private string _ShowMessage;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string ShowMessage
        {
            get { return _ShowMessage; }
            set
            {
                _ShowMessage = value;
                RaisePropertyChanged("ShowMessage");
            }
        }

        #endregion

        /// <summary>
        /// 命令实例
        /// </summary>
        #region 绑定命令 Command
        public ICommand Cmd_UpdateShowMessage
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Ex_UpdateShowMessage();
                });
            }
        }
        #endregion

        /// <summary>
        /// 命令所要执行的方法
        /// </summary>
        #region 命令方法 ExMethord

        private void Ex_UpdateShowMessage()
        {
            this.ShowMessage = "我改变了消息提示";
        }

        #endregion
    }
}
