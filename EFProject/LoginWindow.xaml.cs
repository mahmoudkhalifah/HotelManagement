using AdminUI;
using RoomServiceUI;
using DataLayer.DBContext;
using DataLayer.Entity;
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

namespace EFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        #region login button logic
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                using HotelContext hotelContext = new ();
                var user = hotelContext.People.SingleOrDefault(p=>p.Username==TxtUsername.Text && p.Password == TxtPassword.Password);
                if (user == null)
                    MessageBox.Show("Wrong username or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (user.IsAdmin == true)
                {
                    AdminUI.MainWindow adminWindow = new ();
                    Close();
                    adminWindow.Left = Left;
                    adminWindow.Top = Top;
                    adminWindow.Show();
                    //MessageBox.Show("Welcome again admin :)", "Login succeeded", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (user.IsAdmin == false)
                {
                    RoomServiceUI.MainWindow roomServiceWindow = new ();
                    Close();
                    roomServiceWindow.Left = Left;
                    roomServiceWindow.Top = Top;
                    roomServiceWindow.Show();
                    //MessageBox.Show("Welcome again room service :)", "Login succeeded", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        #endregion

        #region username text box events
        private void TxtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                LblUsername.Visibility = Visibility.Visible;
                if (tb.Text == "Enter username")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                LblUsername.Visibility = Visibility.Hidden;
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Enter username";
                }
            }
        }
        #endregion

        #region password box events
        private void TxtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pb)
            {
                LblPassword.Visibility = Visibility.Visible;
                if (pb.Password == "Enter password")
                {
                    pb.Password = string.Empty;
                }
            }
        }

        private void TxtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pb)
            {
                LblPassword.Visibility = Visibility.Hidden;
                if (pb.Password == string.Empty)
                {
                    pb.Password = "Enter password";
                }
            }
        }
        #endregion

        #region window controls
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
                Close();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                WindowState = WindowState.Minimized;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        #endregion

        private void License_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
                MessageBox.Show("Licesnse Info", "Licesnse", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
