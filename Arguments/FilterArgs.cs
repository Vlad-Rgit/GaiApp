using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Arguments
{
    public class FilterArgs : EventArgs
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public FilterArgs(string oldValue, string newValue)
            => (OldValue, NewValue) = (oldValue, newValue);
    }
}
