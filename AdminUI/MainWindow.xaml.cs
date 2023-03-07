﻿using DialogsUI;
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

            CmbMonth.ItemsSource = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.SkipLast(1);

            List<string> days = new ();
            for (int i = 1; i <= 31; i++)
                days.Add(i.ToString().Length > 1 ? i.ToString():new StringBuilder().Append('0').Append(i).ToString());
            CmbDay.ItemsSource = days;

            CmbState.ItemsSource = new string[] {
            "Alabama ",
            "Alaska ",
            "Arizona ",
            "Arkansas ",
            "California ",
            "Colorado ",
            "Connecticut ",
            "Delaware ",
            "Florida ",
            "Georgia ",
            "Hawaii ",
            "Idaho ",
            "Illinois Indiana ",
            "Iowa ",
            "Kansas ",
            "Kentucky ",
            "Louisiana ",
            "Maine ",
            "Maryland ",
            "Massachusetts ",
            "Michigan ",
            "Minnesota ",
            "Mississippi ",
            "Missouri ",
            "Montana Nebraska ",
            "Nevada ",
            "New Hampshire ",
            "New Jersey ",
            "New Mexico ",
            "New York ",
            "North Carolina ",
            "North Dakota ",
            "Ohio ",
            "Oklahoma ",
            "Oregon ",
            "Pennsylvania Rhode Island ",
            "South Carolina ",
            "South Dakota ",
            "Tennessee ",
            "Texas ",
            "Utah ",
            "Vermont ",
            "Virginia ",
            "Washington ",
            "West Virginia ",
            "Wisconsin ",
            "Wyoming"};

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

        #region Buttons
        private void BtnFood_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new ();
            foodMenu.ShowDialog();
        }
        #endregion

        private void BtnFinalizeBill_Click(object sender, RoutedEventArgs e)
        {
            Bill bill = new ();
            bill.ShowDialog();
        }
    }
}
