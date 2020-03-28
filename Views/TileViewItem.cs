using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GaiApp.Views
{
    public class TileViewItem : DependencyObject
    {
        public static readonly DependencyProperty ItemImageSourceProperty
             = DependencyProperty.Register("ItemImageSource", typeof(object), typeof(TileViewData));

        public static readonly DependencyProperty ItemHeaderProperty
              = DependencyProperty.Register("ItemHeader", typeof(object), typeof(TileViewData));


        public ObservableCollection<TileViewData> TileViewDataCollection { get; set; }
            = new ObservableCollection<TileViewData>();


        public object ItemHeader
        {
            get { return (object)GetValue(ItemHeaderProperty); }
            set { SetValue(ItemHeaderProperty, value); }
        }

        public object ItemImageSource
        {
            get { return (object)GetValue(ItemImageSourceProperty); }
            set { SetValue(ItemImageSourceProperty, value); }
        }



    }


}
