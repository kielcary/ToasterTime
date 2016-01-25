using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace ToasterTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int gridCount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PopTheToast(object sender, RoutedEventArgs e)
        {
            ShowToast(this.MainGrid, "Test");
        }

        public static void ShowToast(Grid baseGrid, string message)
        {
            gridCount ++;

            StackPanel grid = new StackPanel();
            grid.Width = 200;
            grid.Height = 40;
            grid.Background = new System.Windows.Media.SolidColorBrush(Colors.Gray);
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            grid.Margin = new Thickness(0, 0, 0, 30);


            TextBlock text = new TextBlock();
            text.Text = message;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.FontSize = 22;

            grid.Children.Add(text);

            baseGrid.Children.Add(grid);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += (sender, args) =>
            {
                var anim = new DoubleAnimation(0, (Duration) TimeSpan.FromSeconds(1));
                grid.BeginAnimation(UIElement.OpacityProperty, anim);
                anim.Completed += (s, _) => baseGrid.Children.Remove(grid);
                timer.Stop();
            };
            timer.Start();
        }

    }
}
