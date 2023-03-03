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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomServiceUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region window controls
        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                WindowState = WindowState.Minimized;
        }

        private void BtnMaxmize_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    BtnMaxmize.Content = "🗖";
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    BtnMaxmize.Content = "🗗";
                }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        #endregion

        #region panels switching
        private void LblTodo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Label)
            {
                RctTodo.Fill = Brushes.OrangeRed;
                RctOverview.Fill = Brushes.LightGray;

                PnlTodo.Visibility = Visibility.Visible;
                PnlOverview.Visibility = Visibility.Hidden;
            }
        }

        private void LblOverview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                RctTodo.Fill = Brushes.LightGray;
                RctOverview.Fill = Brushes.OrangeRed;

                PnlTodo.Visibility = Visibility.Hidden;
                PnlOverview.Visibility = Visibility.Visible;
            }
        }
        #endregion

    }
}
