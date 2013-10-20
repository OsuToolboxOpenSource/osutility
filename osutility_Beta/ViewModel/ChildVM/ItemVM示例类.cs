using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace osutility_Beta.ViewModel.ChildVM
{
    /// <summary>
    /// 多项列表内包含的对象
    /// </summary>
    public class ItemVM示例类 : ViewModelBase
    {
        public ItemVM示例类(string stringBody = "aItem", bool isCheck = false)
        {
            this.AStringBody = stringBody;
            this.IsBeChecked = isCheck;
        }

        /// <summary>
        /// 回收源
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
        }

        private string _AStringBody;
        /// <summary>
        /// 这是里面的随便一个对象
        /// </summary>
        public string AStringBody
        {
            get { return _AStringBody; }
            set
            {
                _AStringBody = value;
                this.RaisePropertyChanged("AStringBody");
            }
        }

        private bool _IsBeChecked;
        /// <summary>
        /// 该项是否被选中
        /// </summary>
        public bool IsBeChecked
        {
            get { return _IsBeChecked; }
            set
            {
                _IsBeChecked = value;
                this.RaisePropertyChanged("IsBeChecked");
            }
        }


    }
}
