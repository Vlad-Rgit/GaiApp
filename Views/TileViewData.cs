using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GaiApp.Views
{
    public class TileViewData : DependencyObject
    {

        public static readonly DependencyProperty DataProperty 
              = DependencyProperty.Register("Data", typeof(object), typeof(TileViewData));

        public static readonly DependencyProperty TitleProperty 
              = DependencyProperty.Register("Title", typeof(object), typeof(TileViewData));


      
        public object Title
        {
            get { return (object)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

    }
}
