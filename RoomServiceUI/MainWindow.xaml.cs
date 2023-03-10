using DataLayer.DBContext;
using DataLayer.Entity;
using DialogsUI;
using Microsoft.EntityFrameworkCore;
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

        int lunch, breakfast, dinner;

        HotelContext hotelContext = new();

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

        private void BtnChangeFood_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new(false);
            foodMenu.Breakfast = breakfast.ToString();
            foodMenu.Lunch = lunch.ToString();
            foodMenu.Dinner = dinner.ToString();
            foodMenu.ShowDialog();
            breakfast =int.Parse(foodMenu.Breakfast);
            lunch =int.Parse(foodMenu.Lunch);
            dinner =int.Parse(foodMenu.Dinner);
            TxtBreakfast.Text = foodMenu.Breakfast;
            TxtLunch.Text = foodMenu.Lunch;
            TxtDinner.Text = foodMenu.Dinner;

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GrdOverview.ItemsSource = hotelContext.Reservations.Join(hotelContext.Customers, r => r.Customer.CustomerID, c => c.CustomerID, (r, c) => new {
                c.Fname,
                c.Lname,
                c.Gender,
                c.Email,
                c.Phone,
                c.Birthday,
                c.AptSuite,
                c.City,
                c.State,
                c.ZipCode,
                r.RoomNum,
                r.RoomFloor,
                r.RoomType,
                r.GuestsNum,
                r.CheckIn,
                r.ArrivalDate,
                r.LeavingDate,
                r.BreakfastQty,
                r.LunchQty,
                r.DinnerQty,
                r.Cleaning,
                r.Towel,
                r.SweetSurprise,
                r.SupplyStatus,
            }).ToList();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hotelContext.Reservations.Load();
            hotelContext.Customers.Load();

        }

        private void LstOnLine_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LstOnLine.ItemsSource = hotelContext.Customers.Local.Where(c => c.Reservation.SupplyStatus == false).Select(c => new { customerId = c.CustomerID, info = $"{c.CustomerID} | {c.Fname} {c.Lname} | {c.Phone}" });
            LstOnLine.SelectedValuePath = "customerId";
            LstOnLine.DisplayMemberPath = "info";

            GrdOverview.ItemsSource = hotelContext.Reservations.Join(hotelContext.Customers, r => r.Customer.CustomerID, c => c.CustomerID, (r, c) => new {
                c.Fname,
                c.Lname,
                c.Gender,
                c.Email,
                c.Phone,
                c.Birthday,
                c.AptSuite,
                c.City,
                c.State,
                c.ZipCode,
                r.RoomNum,
                r.RoomFloor,
                r.RoomType,
                r.GuestsNum,
                r.CheckIn,
                r.ArrivalDate,
                r.LeavingDate,
                r.BreakfastQty,
                r.LunchQty,
                r.DinnerQty,
                r.Cleaning,
                r.Towel,
                r.SweetSurprise,
                r.SupplyStatus,
            }).ToList();

        }

        private void LstOnLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LstOnLine.SelectedValue != null)
            {
                Customer customer = hotelContext.Customers.Local.FirstOrDefault(c => c.CustomerID == (int)LstOnLine.SelectedValue);
                if(customer != null)
                {
                    TxtBreakfast.Text = customer.Reservation.BreakfastQty.ToString();
                    breakfast = customer.Reservation.BreakfastQty;
                    TxtDinner.Text = customer.Reservation.DinnerQty.ToString();
                    dinner = customer.Reservation.DinnerQty;
                    TxtLunch.Text = customer.Reservation.LunchQty.ToString();
                    lunch = customer.Reservation.LunchQty;
                    TxtFirstName.Text = customer.Fname.ToString();
                    TxtLastName.Text = customer.Lname.ToString();
                    TxtPhone.Text = customer.Phone.ToString();
                    TxtRoomNum.Text = customer.Reservation?.RoomNum.ToString();
                    TxtRoomType.Text = customer.Reservation?.RoomType.ToString();
                    TxtFloor.Text = customer.Reservation?.RoomFloor.ToString();

                    ChkCleaning.IsChecked = customer.Reservation.Cleaning;
                    ChkTowels.IsChecked = customer.Reservation.Towel;
                    ChkSweetestSurprise.IsChecked = customer.Reservation.SweetSurprise;
                    ChkFoodStatus.IsChecked = customer.Reservation.SupplyStatus;
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = hotelContext.Customers.Local.FirstOrDefault(c => c.CustomerID == (int)LstOnLine.SelectedValue);
            customer.Reservation.SupplyStatus = ChkFoodStatus.IsChecked??false;
            customer.Reservation.DinnerQty = dinner;
            customer.Reservation.LunchQty = lunch;
            customer.Reservation.BreakfastQty = breakfast;
            hotelContext.SaveChanges();
            LstOnLine.UnselectAll();
            LoadData();
        }
    }
}
