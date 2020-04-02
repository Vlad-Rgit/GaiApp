using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GaiApp.UserControls
{
    /// <summary>
    /// Interaction logic for TextboxWithPopup.xaml
    /// </summary>
    public partial class TextboxWithList : UserControl
    {
        public static readonly DependencyProperty TextProperty =
           TextBox.TextProperty.AddOwner(typeof(TextboxWithList));

        public static readonly DependencyProperty ItemsSourceProperty =
              ItemsControl.ItemsSourceProperty.AddOwner(typeof(TextboxWithList),
                  new PropertyMetadata(new PropertyChangedCallback(ItemSourceChanged)));

        public static readonly DependencyProperty DisplayMemberPathProperty =
           ItemsControl.DisplayMemberPathProperty.AddOwner(typeof(TextboxWithList));


        public static readonly RoutedEvent ListUpdatedEvent =
            EventManager.RegisterRoutedEvent("ListUpdated", RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), typeof(TextboxWithList));

        public IEnumerable<object> Collection { get; private set; }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public event RoutedEventHandler ListUpdated
        {
            add => AddHandler(ListUpdatedEvent, value);
            remove => RemoveHandler(ListUpdatedEvent, value);
        }

        public static void ItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextboxWithList txtbox = (d as TextboxWithList);

            txtbox.list.Items.Clear();

            foreach(var i in txtbox.ItemsSource)
            {
                txtbox.list.Items.Add(i);
            }
        }


        public TextboxWithList()
        {
            InitializeComponent();
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            list.Items.Clear();

            foreach(var i in ItemsSource)
            {
                if (i.ToString().Contains(txt.Text))
                {
                    list.Items.Add(i);
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                txt.Text = list.SelectedItem.ToString();
            }
        }
    }
}
