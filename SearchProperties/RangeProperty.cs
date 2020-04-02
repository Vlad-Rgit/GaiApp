using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GaiApp.SearchProperties
{
    public class RangeProperty : SearchProperty
    {
        public Control BeginControl { get; set; }
        public Control EndControl { get; set; }

        public dynamic GetDynamicValue(object owner)
             => PropertyInfo?.GetValue(owner);
    }
}
