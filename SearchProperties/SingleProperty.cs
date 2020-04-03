using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GaiApp.SearchProperties
{
    public struct SingleProperty 
    {
        public Control Control { get; set; }
        public PropertyInfo PropertyInfo { get; set; }

        public object GetValue(object owner)
            => PropertyInfo.GetValue(owner);

        public string GetStringValue(object owner)
            => PropertyInfo.GetValue(owner).ToString();
    }

}
