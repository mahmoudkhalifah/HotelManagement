using DataLayer.DBContext;
using DataLayer.Entity;
using DialogsUI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        HotelContext hotelContext = new();
        int lunch, breakfast, dinner, roomBill;
        bool towels, cleaning, ssurprise;
        string cardCVV, cardNumber, cardExp, cardType;
        float totalBill, foodBill;
        public MainWindow()
        {
            InitializeComponent();


            CmbMonth.ItemsSource = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames.SkipLast(1);

            List<string> days = new();
            for (int i = 1; i <= 31; i++)
                days.Add(i.ToString().Length > 1 ? i.ToString() : new StringBuilder().Append('0').Append(i).ToString());
            CmbDay.ItemsSource = days;

            CmbState.ItemsSource = new string[] {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming"};

            PckArrivalDate.Text = DateTime.Now.ToString();
            PckDepertureDate.Text = DateTime.Now.AddDays(1).ToString();

            CmbNumOfGuests.ItemsSource = new string[] { "1", "2", "3", "4", "5", "6" };

            CmbRoomType.ItemsSource = new string[] { "Single","Double","Twin","Duplex","Suite" };
            //CmbFloor.ItemsSource = new string[] { "1", "2", "3", "4", "5" };
            //CmbRoomNumber.ItemsSource = new string[] { "102", "202", "302", "402", "502" };

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
        private void LblReservation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Label)
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
            FoodMenu foodMenu = new(true);
            foodMenu.Breakfast = breakfast.ToString();
            foodMenu.Lunch = lunch.ToString();
            foodMenu.Dinner = dinner.ToString();
            foodMenu.Towels = towels;
            foodMenu.Cleaning = cleaning;
            foodMenu.SweetestSurprise = ssurprise;
            foodMenu.ShowDialog();
            int.TryParse(foodMenu.Breakfast,out breakfast);
            int.TryParse(foodMenu.Lunch,out lunch);
            int.TryParse(foodMenu.Dinner,out dinner);

            towels = foodMenu.Towels;
            cleaning = foodMenu.Cleaning;
            ssurprise = foodMenu.SweetestSurprise;
        }

        private void BtnFinalizeBill_Click(object sender, RoutedEventArgs e)
        {
            if ((string)CmbRoomType.SelectedValue == "Single")
                roomBill = 149;
            else if ((string)CmbRoomType.SelectedValue == "Double")
                roomBill = 299;
            else if ((string)CmbRoomType.SelectedValue == "Twin")
                roomBill = 349;
            else if ((string)CmbRoomType.SelectedValue == "Duplex")
                roomBill = 399;
            else if ((string)CmbRoomType.SelectedValue == "Suite")
                roomBill = 499;

            foodBill = 7 * breakfast + 15 * lunch + 15 * dinner;
            Bill bill = new(roomBill,foodBill);
            bill.CVV=cardCVV;
            bill.CardNumber = cardNumber;
            bill.Exp = cardExp;
            bill.CardType = cardType;
            bill.ShowDialog();

            cardCVV = bill.CVV;
            cardExp = bill.Exp;
            cardType = bill.CardType;
            cardNumber = bill.CardNumber;
            totalBill = bill.TotalBill;

            BtnSubmit.Visibility = Visibility.Visible;

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(BtnUpdate.Visibility == Visibility.Hidden)
            {
                BtnUpdate.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                CmbReservationsEdit.Visibility = Visibility.Visible;
            }
            else
            {
                BtnUpdate.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
                CmbReservationsEdit.Visibility = Visibility.Hidden;
            }
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            GrdUniversalSearch.ItemsSource = hotelContext.Reservations.Local.Join(hotelContext.Payments, r => r.Payment.PaymentID, p => p.PaymentID, (r, p) => new { r, p }).Join(hotelContext.Customers.Local, r => r.r.Customer.CustomerID, c => c.CustomerID, (r, c) => new {
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
                r.r.RoomNum,
                r.r.RoomFloor,
                r.r.RoomType,
                r.r.GuestsNum,
                r.r.CheckIn,
                r.r.ArrivalDate,
                r.r.LeavingDate,
                r.r.BreakfastQty,
                r.r.LunchQty,
                r.r.DinnerQty,
                r.r.Cleaning,
                r.r.Towel,
                r.r.SweetSurprise,
                r.r.SupplyStatus,
                r.p.CardType,
                r.p.CardNumber,
                r.p.CardCVV,
                r.p.CardExp,
                r.p.FoodBill,
                r.p.TotalBill,
            })
            .Where(r =>r.Fname.Contains(TxtSearch.Text) || r.Lname.Contains(TxtSearch.Text)
                    || r.Email.Contains(TxtSearch.Text) || r.Gender.Contains(TxtSearch.Text)
                    || r.State.Contains(TxtSearch.Text) || r.City.Contains(TxtSearch.Text)
                    || r.RoomNum.ToString().Contains(TxtSearch.Text) || r.RoomType.Contains(TxtSearch.Text)
                    || r.Phone.Contains(TxtSearch.Text))
            .ToList();
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new()
            {
                Fname = TxtFirstName.Text, Lname = TxtLastName.Text,
                City = TxtCity.Text, AptSuite = TxtApt.Text,
                State = CmbState.Text,
                Birthday = TxtYear.Text +"-"+ CmbMonth.Text +"-"+ CmbDay.Text,
                Email = TxtEmail.Text, ZipCode = TxtZip.Text,
                Gender = CmbGender.Text, Phone = TxtPhone.Text,
            };
            Payment payment = new() {
                CardCVV=cardCVV, CardExp=cardExp, CardNumber=cardNumber,
                CardType=cardType, FoodBill=foodBill, TotalBill=totalBill
            };
            Reservation reservation = new()
            {
                CheckIn = ChkCheckIn.IsChecked ?? false,
                SupplyStatus = false,
                ArrivalDate = PckArrivalDate.SelectedDate ?? DateTime.Now,
                LeavingDate = PckDepertureDate.SelectedDate ?? DateTime.Now.AddDays(1),
                DinnerQty = dinner,
                LunchQty = lunch,
                BreakfastQty = breakfast,
                Cleaning = cleaning,
                Towel = towels,
                SweetSurprise = ssurprise,
                RoomType = CmbRoomType.Text,
                RoomFloor = int.Parse(CmbFloor.Text),
                RoomNum = int.Parse(CmbRoomNumber.Text),
                GuestsNum = int.Parse(CmbNumOfGuests.Text),
                Payment = payment,
                Customer = customer,
            };

            hotelContext.Reservations.Add(reservation);
            hotelContext.SaveChanges();

        }
        #endregion

        #region Loaded
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GrdReservationAdvView.ItemsSource = hotelContext.Reservations.Local.Join(hotelContext.Payments.Local, r => r.Payment.PaymentID, p => p.PaymentID, (r, p) => new { r, p }).Join(hotelContext.Customers.Local, r => r.r.Customer.CustomerID, c => c.CustomerID, (r, c) => new {
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
                r.r.RoomNum,
                r.r.RoomFloor,
                r.r.RoomType,
                r.r.GuestsNum,
                r.r.CheckIn,
                r.r.ArrivalDate,
                r.r.LeavingDate,
                r.r.BreakfastQty,
                r.r.LunchQty,
                r.r.DinnerQty,
                r.r.Cleaning,
                r.r.Towel,
                r.r.SweetSurprise,
                r.r.SupplyStatus,
                r.p.CardType,
                r.p.CardNumber,
                r.p.CardCVV,
                r.p.CardExp,
                r.p.FoodBill,
                r.p.TotalBill,
            }).ToList();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hotelContext.Reservations.Load();
            hotelContext.Payments.Load();
            hotelContext.Customers.Load();
            LoadData();
        }

        private void LoadData()
        {
            CmbRoomNumber.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == false).Select(r => r.RoomNum).ToList();
            CmbFloor.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == false).Select(r => r.RoomFloor).Distinct().ToList();

            CmbReservationsEdit.ItemsSource = hotelContext.Customers.Local.Where(c => c.Reservation.SupplyStatus == false).Select(c => new { customerId = c.CustomerID, info = $"{c.CustomerID} | {c.Fname} {c.Lname} | {c.Phone}" });
            CmbReservationsEdit.SelectedValuePath = "customerId";
            CmbReservationsEdit.DisplayMemberPath = "info";

            LstReserved.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == false).Select(r => $"[{r.RoomNum}] {r.RoomType} {r.Customer.CustomerID} {r.Customer.Fname} {r.Customer.Lname} {r.Customer.Phone} {r.ArrivalDate.ToString("MM/dd/yyyy")} {r.LeavingDate.Date.ToString("MM/dd/yyyy")}").ToList();
            LstOccupied.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == true).Select(r => $"[{r.RoomNum}] {r.RoomType} {r.Customer.CustomerID} {r.Customer.Fname} {r.Customer.Lname} {r.Customer.Phone}").ToList();

            GrdReservationAdvView.ItemsSource = hotelContext.Reservations.Local.Join(hotelContext.Payments.Local, r => r.Payment.PaymentID, p => p.PaymentID, (r, p) => new { r, p }).Join(hotelContext.Customers.Local, r => r.r.Customer.CustomerID, c => c.CustomerID, (r, c) => new {
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
                r.r.RoomNum,
                r.r.RoomFloor,
                r.r.RoomType,
                r.r.GuestsNum,
                r.r.CheckIn,
                r.r.ArrivalDate,
                r.r.LeavingDate,
                r.r.BreakfastQty,
                r.r.LunchQty,
                r.r.DinnerQty,
                r.r.Cleaning,
                r.r.Towel,
                r.r.SweetSurprise,
                r.r.SupplyStatus,
                r.p.CardType,
                r.p.CardNumber,
                r.p.CardCVV,
                r.p.CardExp,
                r.p.FoodBill,
                r.p.TotalBill,
            }).ToList();
        }

        private void CmbReservationsEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer customer = hotelContext.Customers.Local.FirstOrDefault(c=>c.CustomerID == (int)CmbReservationsEdit.SelectedValue);
            if (customer != null)
            {
                TxtFirstName.Text = customer.Fname;
                TxtLastName.Text = customer.Lname;
                TxtPhone.Text = customer.Phone;
                TxtEmail.Text = customer.Email;
                TxtCity.Text = customer.City;
                TxtZip.Text = customer.ZipCode;
                TxtApt.Text = customer.AptSuite;

                CmbGender.Text = customer.Gender;
                CmbState.Text = customer.State;

                string[] birthdate = customer.Birthday.Split('-');
                TxtYear.Text = birthdate[0];
                CmbMonth.Text = birthdate[1];
                CmbDay.Text = birthdate[2];

                CmbRoomNumber.Text = customer.Reservation.RoomNum.ToString();
                CmbFloor.Text = customer.Reservation.RoomFloor.ToString();
                CmbNumOfGuests.Text = customer.Reservation.GuestsNum.ToString();
                CmbRoomType.Text = customer.Reservation.RoomType.ToString();

                PckArrivalDate.SelectedDate = customer.Reservation.ArrivalDate;
                PckDepertureDate.SelectedDate = customer.Reservation.LeavingDate;

                breakfast = customer.Reservation.BreakfastQty;
                lunch = customer.Reservation.LunchQty;
                dinner = customer.Reservation.DinnerQty;

                towels = customer.Reservation.Towel;
                cleaning = customer.Reservation.Cleaning;
                ssurprise = customer.Reservation.SweetSurprise;


                foodBill = customer.Reservation.Payment.FoodBill;
                totalBill = customer.Reservation.Payment.TotalBill;

                cardCVV = customer.Reservation.Payment.CardCVV;
                cardExp = customer.Reservation.Payment.CardExp;
                cardNumber = customer.Reservation.Payment.CardNumber;
                cardType = customer.Reservation.Payment.CardType;


                ChkCheckIn.IsChecked = customer.Reservation.CheckIn;

                BtnUpdate.IsEnabled = true;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = hotelContext.Customers.Local.FirstOrDefault(c => c.CustomerID == (int)CmbReservationsEdit.SelectedValue);
            if (customer != null)
            {
                customer.Fname = TxtFirstName.Text;
                customer.Lname = TxtLastName.Text;
                customer.Phone = TxtPhone.Text;
                customer.Email = TxtEmail.Text;
                customer.City = TxtCity.Text;
                customer.ZipCode = TxtZip.Text;
                customer.AptSuite = TxtApt.Text;

                customer.Gender = CmbGender.Text;
                customer.State = CmbState.Text;

                customer.Birthday = TxtYear.Text +"-"+ CmbMonth.Text +"-"+ CmbDay.Text;

                customer.Reservation.RoomNum = int.Parse(CmbRoomNumber.Text);
                customer.Reservation.RoomFloor = int.Parse(CmbFloor.Text);
                customer.Reservation.GuestsNum = int.Parse(CmbNumOfGuests.Text);
                customer.Reservation.RoomType = CmbRoomType.Text;

                customer.Reservation.ArrivalDate = PckArrivalDate.SelectedDate ?? DateTime.Now;
                customer.Reservation.LeavingDate = PckDepertureDate.SelectedDate ?? DateTime.Now.AddDays(1);

                customer.Reservation.BreakfastQty = breakfast;
                customer.Reservation.LunchQty = lunch;
                customer.Reservation.DinnerQty = dinner;

                customer.Reservation.Towel = towels;
                customer.Reservation.Cleaning = cleaning;
                customer.Reservation.SweetSurprise = ssurprise;

                customer.Reservation.Payment.FoodBill = foodBill;
                customer.Reservation.Payment.TotalBill = totalBill;

                customer.Reservation.Payment.CardCVV = cardCVV;
                customer.Reservation.Payment.CardExp = cardExp;
                customer.Reservation.Payment.CardNumber = cardNumber;
                customer.Reservation.Payment.CardType = cardType;

                customer.Reservation.CheckIn = ChkCheckIn.IsChecked ?? false;

                hotelContext.SaveChanges();
                LoadData();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = hotelContext.Customers.Local.FirstOrDefault(c => c.CustomerID == (int)CmbReservationsEdit.SelectedValue);
            hotelContext.Reservations.Remove(customer.Reservation);
            hotelContext.Payments.Remove(customer.Reservation.Payment);
            hotelContext.Customers.Remove(customer);
            hotelContext.SaveChanges();
            LoadData();
        }

        #endregion

        #region Placeholder
        private void TxtFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "First")
                {
                    tb.Text = string.Empty;
                }
            }
        }
        private void TxtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "First";
                }
            }
        }

        private void TxtLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Last")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Last";
                }
            }
        }

        private void TxtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "(999) 999-999")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "(999) 999-999";
                }
            }
        }

        private void TxtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "mail@ex.com")
                {
                    tb.Text = string.Empty;
                }
            }
        }
        private void TxtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "mail@ex.com";
                }
            }
        }

        private void TxtYear_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Year")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Year";
                }
            }
        }

        private void LstOccupied_Loaded(object sender, RoutedEventArgs e)
        {
            LstOccupied.ItemsSource = hotelContext.Reservations.Local.Where(r=>r.CheckIn == true).Select(r=> $"[{r.RoomNum}] {r.RoomType} {r.Customer.CustomerID} {r.Customer.Fname} {r.Customer.Lname} {r.Customer.Phone}").ToList();
        }

        private void LstReserved_Loaded(object sender, RoutedEventArgs e)
        {
            //LstReserved.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == false).ToList();
            LstReserved.ItemsSource = hotelContext.Reservations.Local.Where(r => r.CheckIn == false).Select(r => $"[{r.RoomNum}] {r.RoomType} {r.Customer.CustomerID} {r.Customer.Fname} {r.Customer.Lname} {r.Customer.Phone} {r.ArrivalDate.ToString("MM/dd/yyyy")} {r.LeavingDate.Date.ToString("MM/dd/yyyy")}").ToList();
        }


        private void TxtStreet_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Street address")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtStreet_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Street address";
                }
            }
        }

        private void TxtApt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Apt./Suite")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtApt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Apt./Suite";
                }
            }
        }

        private void TxtCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "City")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtCity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "City";
                }
            }
        }
        private void TxtZip_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Zip Code")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtZip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Zip Code";
                }
            }
        }

        #endregion

        private void PckArrivalDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = PckArrivalDate.SelectedDate??DateTime.Now;
            PckDepertureDate.SelectedDate = date.AddDays(1);
        }
    }
}
