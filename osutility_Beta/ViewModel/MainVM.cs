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
    class MainVM : ObservableObject
    {
        public MainVM()
        {
            //初始化源
            this.ShowMessage = "数据模型加载";

            this.AvmListItem = new List<ChildVM.ItemVM示例类>() 
            {
                 new ChildVM.ItemVM示例类(){ AStringBody="1st Item"},
                 new ChildVM.ItemVM示例类(){ AStringBody="2nd Item"},
                 new ChildVM.ItemVM示例类(){ AStringBody="3rd Item"},
            };
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

        private List<ChildVM.ItemVM示例类> _AvmListItem;
        /// <summary>
        /// 动态获取列表与集合示范。
        /// </summary>
        public List<ChildVM.ItemVM示例类> AvmListItem
        {
            get { return _AvmListItem; }
            set
            {
                _AvmListItem = value;
                this.RaisePropertyChanged("AvmListItem");
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
