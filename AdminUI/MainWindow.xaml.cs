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

namespace AdminUI
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
                } else
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
        private void LblReservation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(sender is Label)
            {
                RctReservation.Fill = Brushes.GreenYellow;
                RctReservationAdvView.Fill = Brushes.LightGray;
                RctRoomAvailibility.Fill = Brushes.LightGray;
                RctUniversalSearch.Fill = Brushes.LightGray;

                PnlReservation.Visibility = Visibility.Visible;
                PnlReservationAdvView.Visibility = Visibility.Hidden;
                PnlRoomAvailibility.Visibility = Visibility.Hidden;
                PnlUniversalSearch.Visibility = Visibility.Hidden;
            }
        }

        private void LblUniversalSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                RctReservation.Fill = Brushes.LightGray;
                RctReservationAdvView.Fill = Brushes.LightGray;
                RctRoomAvailibility.Fill = Brushes.LightGray;
                RctUniversalSearch.Fill = Brushes.GreenYellow;

                PnlReservation.Visibility = Visibility.Hidden;
                PnlReservationAdvView.Visibility = Visibility.Hidden;
                PnlRoomAvailibility.Visibility = Visibility.Hidden;
                PnlUniversalSearch.Visibility = Visibility.Visible;
            }
        }

        private void LblReservationAdvView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                RctReservation.Fill = Brushes.LightGray;
                RctReservationAdvView.Fill = Brushes.GreenYellow;
                RctRoomAvailibility.Fill = Brushes.LightGray;
                RctUniversalSearch.Fill = Brushes.LightGray;

                PnlReservation.Visibility = Visibility.Hidden;
                PnlReservationAdvView.Visibility = Visibility.Visible;
                PnlRoomAvailibility.Visibility = Visibility.Hidden;
                PnlUniversalSearch.Visibility = Visibility.Hidden;
            }
        }

        private void LblRoomAvailibility_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                RctReservation.Fill = Brushes.LightGray;
                RctReservationAdvView.Fill = Brushes.LightGray;
                RctRoomAvailibility.Fill = Brushes.GreenYellow;
                RctUniversalSearch.Fill = Brushes.LightGray;

                PnlReservation.Visibility = Visibility.Hidden;
                PnlReservationAdvView.Visibility = Visibility.Hidden;
                PnlRoomAvailibility.Visibility = Visibility.Visible;
                PnlUniversalSearch.Visibility = Visibility.Hidden;
            }
        }
        #endregion
    }
}
