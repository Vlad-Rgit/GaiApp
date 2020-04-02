using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace GaiApp.Views
{

    [ContentProperty("TileViewRows")]
    public class TileView : ViewBase
    {
        #region Dp Properties
        public static readonly DependencyProperty TileViewRowsProperty =
            DependencyProperty.Register("TileViewRows", typeof(ObservableCollection<TileViewRow>),
                typeof(TileView));


        public static readonly DependencyProperty ItemHeaderPathProperty =
            DependencyProperty.Register("ItemHeaderPath", typeof(string), typeof(TileView)
                , new PropertyMetadata(null));


        public static readonly DependencyProperty ItemImageSourcePathProperty =
            DependencyProperty.Register("ItemImageSourcePath", typeof(string), typeof(TileView)
                , new PropertyMetadata(null));

        public static readonly DependencyProperty CurrentTileProperty =
            DependencyProperty.Register("CurrentTile", typeof(TileViewItem), typeof(TileView));

        public static readonly DependencyProperty HasToolButtonProperty =
            DependencyProperty.Register("HasToolButton", typeof(bool), typeof(TileView), new PropertyMetadata(false));


        public static readonly DependencyProperty ToolButtonTextProperty =
            DependencyProperty.Register("ToolButtonText", typeof(string), typeof(TileView), new PropertyMetadata(String.Empty));

        public static readonly DependencyProperty ToolButtonCommandProperty =
    DependencyProperty.Register("ToolButtonCommand", typeof(ICommand), typeof(TileView));

        public static readonly DependencyProperty ToolButtonCommandParametrPathProperty =
            DependencyProperty.Register("ToolButtonCommandParametr", typeof(object), typeof(TileView), new PropertyMetadata(String.Empty));


        public static readonly DependencyProperty IsPoppedUpProperty =
            DependencyProperty.Register("IsPoppedUp", typeof(bool), typeof(TileView));

        #endregion


        #region Public Properties
        public ObservableCollection<TileViewRow> TileViewRows
        {
            get { return (ObservableCollection<TileViewRow>)GetValue(TileViewRowsProperty); }
            set { SetValue(TileViewRowsProperty, value); }
        }

        public string ItemHeaderPath
        {
            get { return (string)GetValue(ItemHeaderPathProperty); }
            set { SetValue(ItemHeaderPathProperty, value); }
        }

        public string ItemImageSourcePath
        {
            get { return (string)GetValue(ItemImageSourcePathProperty); }
            set { SetValue(ItemImageSourcePathProperty, value); }
        }

        protected override object DefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileView"); }
        }

        protected override object ItemContainerDefaultStyleKey
        {
            get { return new ComponentResourceKey(GetType(), "TileViewItem"); }
        }

        public bool HasToolButton
        {
            get { return (bool)GetValue(HasToolButtonProperty); }
            set { SetValue(HasToolButtonProperty, value); }
        }

        public string ToolButtonText
        {
            get { return (string)GetValue(ToolButtonTextProperty); }
            set { SetValue(ToolButtonTextProperty, value); }
        }

        public ICommand ToolButtonCommand
        {
            get { return (ICommand)GetValue(ToolButtonCommandProperty); }
            set { SetValue(ToolButtonCommandProperty, value); }
        }

        public string ToolButtonCommandParametrPath
        {
            get { return (string)GetValue(ToolButtonCommandParametrPathProperty); }
            set { SetValue(ToolButtonCommandParametrPathProperty, value); }
        }

        public bool IsPoppedUp
        {
            get { return (bool)GetValue(IsPoppedUpProperty); }
            set { SetValue(IsPoppedUpProperty, value); }
        }


        public ObservableCollection<TileViewItem> TileViewItems { get; set; } = new ObservableCollection<TileViewItem>();

        #endregion

        public TileView()
        {
            TileViewRows = new ObservableCollection<TileViewRow>();
        }

        protected override void PrepareItem(ListViewItem item)
        {
            base.PrepareItem(item);

            TileViewItem tileViewItem = new TileViewItem();

            if (ItemHeaderPath != null)
            {
                Binding bindingHeader = new Binding();
                bindingHeader.Path = new PropertyPath(ItemHeaderPath);
                bindingHeader.Source = item.Content;
                bindingHeader.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(tileViewItem, TileViewItem.ItemHeaderProperty, bindingHeader);
            }

            if (ItemImageSourcePath != null)
            {
                Binding bindingImage = new Binding();
                bindingImage.Path = new PropertyPath(ItemImageSourcePath);
                bindingImage.Source = item.Content;
                bindingImage.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(tileViewItem, TileViewItem.ItemImageSourceProperty, bindingImage);
            }


            if (ToolButtonCommandParametrPath != String.Empty)
            {
                Binding bindinParametrPath = new Binding();
                bindinParametrPath.Path = new PropertyPath(ToolButtonCommandParametrPath);
                bindinParametrPath.Source = item.Content;
                bindinParametrPath.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(tileViewItem, TileViewItem.CommandParametrProperty, bindinParametrPath);
            }


            foreach (var r in TileViewRows)
            {
                Binding bindingData = new Binding();
                bindingData.Path = new PropertyPath(r.DisplayMemberPath);
                bindingData.Source = item.Content;
                bindingData.Mode = BindingMode.OneWay;

                Binding bindingTitle = new Binding();
                bindingTitle.Path = new PropertyPath("Title");
                bindingTitle.Source = r;
                bindingTitle.Mode = BindingMode.OneWay;

                TileViewData data = new TileViewData();

                BindingOperations.SetBinding(data, TileViewData.DataProperty, bindingData);

                BindingOperations.SetBinding(data, TileViewData.TitleProperty, bindingTitle);

                tileViewItem.TileViewDataCollection.Add(data);
            }

            TileViewItems.Add(tileViewItem);

            Binding tileViewItemBinding = new Binding();

            tileViewItemBinding.Source = this;
            tileViewItemBinding.Path = new PropertyPath($"TileViewItems[{TileViewItems.Count - 1}]");
            tileViewItemBinding.Mode = BindingMode.OneWay;


            item.SetBinding(ListViewItem.TagProperty, tileViewItemBinding);

            item.MouseRightButtonUp += Popup;
        }


        private void Popup(object sender, EventArgs args)
        {
            IsPoppedUp = !IsPoppedUp;
        }
    }
}
