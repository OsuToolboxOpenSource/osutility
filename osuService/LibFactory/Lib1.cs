using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace osuService.LibFactory
{
    /// <summary>
    /// 这是一个类工厂，用于公开所有Service逻辑，与界面交互的唯一通道
    /// </summary>
    class Lib1
    {
        public Class_1.ClassTemp Class1()
        {
            return new Class_1.ClassTemp();
        }
    }
}
