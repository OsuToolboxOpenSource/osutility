using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;

namespace osutility_Beta.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TestViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the Test class.
        /// </summary>
        public TestViewModel()
        {
            //初始化源
            ShowMessage = "可以输入要显示的信息，以便显示。";

            AvmListItem = new List<ChildVM.ItemVM示例类>() 
            {
                 new ChildVM.ItemVM示例类(){ AStringBody="1st Item"},
                 new ChildVM.ItemVM示例类(){ AStringBody="2nd Item"},
                 new ChildVM.ItemVM示例类(){ AStringBody="3rd Item"},
            };
        }

        /// <summary>
        /// 回收源
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
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
            System.Windows.MessageBox.Show(ShowMessage);
        }

        #endregion
    }
}