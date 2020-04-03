using GaiApp.SearchProperties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaiApp.Collectons
{
    public class FilterCollection: ObservableCollection<Filter>
    {
        protected override void RemoveItem(int index)
        {
            Items[index].SearchString = "";
            base.RemoveItem(index);
        }
    }
}
