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
    class ItemVM示例类 : ObservableObject
    {
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

    }
}
