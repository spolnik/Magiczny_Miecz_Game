using System.Collections;
using System.ComponentModel;
using System.Windows;

namespace MagicznyMiecz.GUI.LayoutPanels
{
    /// <summary>
    /// Interaction logic for BoardRingControl.xaml
    /// </summary>
    public partial class BoardRingControl
    {
        [BindableAttribute(true)]
        public FrameworkElement Interior
        {
            get { return (FrameworkElement)GetValue(InteriorProperty); }
            set { SetValue(InteriorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Interior.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InteriorProperty =
            DependencyProperty.Register("Interior", typeof(FrameworkElement), typeof(BoardRingControl), new UIPropertyMetadata(null));



        [BindableAttribute(true)]
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(BoardRingControl), new PropertyMetadata(ItemsSourceChanged));


        public DataTemplate ItemTemplate { get; set; }

        private static void ItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as BoardRingControl;

            if (control == null) return;

            control.OnItemsSourceChanged(e);
        }

        protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
                ClearItems();
            if (e.NewValue != null)
                BindItems((IEnumerable) e.NewValue);
        }

        private void ClearItems()
        {
            if (this.ring == null) return;

            //var first = this.ring.Children[0];

            this.ring.Children.Clear();

            //this.ring.Children.Add(first);
        }

        private void BindItems(IEnumerable items)
        {
            if (this.ring == null) return;

            if (this.Interior != null)
                this.ring.Children.Add(this.Interior);

            foreach (var item in items)
            {
                if (item is BoardRingControl)
                    continue;

                var obj = ItemTemplate.LoadContent() as FrameworkElement;
                if (obj == null) continue;
                obj.DataContext = item;
                this.ring.Children.Add(obj);
            }
        }



        //public FrameworkElement Content
        //{
        //    get { return (FrameworkElement)GetValue(ContentProperty); }
        //    set { SetValue(ContentProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ContentProperty =
        //    DependencyProperty.Register("Content", typeof(FrameworkElement), typeof(BoardRingControl), new UIPropertyMetadata(null));

        public BoardRingControl()
        {
            InitializeComponent();

            //this.DataContext = this;
        }
    }
}
