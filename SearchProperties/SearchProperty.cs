using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GaiApp.SearchProperties
{
    public struct SearchProperty
    {
        public Control Control { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}
