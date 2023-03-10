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

namespace DialogsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FoodMenu : Window
    {
        public FoodMenu(bool isAdmin)
        {
            InitializeComponent();
            if(isAdmin )
            {
                PnlSpecialNeeds.Visibility = Visibility.Visible;
            }
            else
            {
                PnlSpecialNeeds.Visibility= Visibility.Hidden;
            }
        }

        string breakfast;
        public string Breakfast
        {
            get { return breakfast; }
            set
            {
                if (int.Parse(value) > 0)
                {
                    breakfast = value;
                    TxtBreakfast.Text = value;
                    ChkBreakfast.IsChecked = true;
                }
            }
        }
        string lunch;
        public string Lunch
        {
            get { return lunch; }
            set
            {
                if (int.Parse(value) > 0)
                {
                    lunch = value;
                    TxtLunch.Text = value;
                    ChkLunch.IsChecked = true;
                }
            }
        }
        string dinner;
        public string Dinner
        {
            get { return dinner; }
            set
            {
                if(int.Parse(value)>0)
                {
                    dinner = value;
                    TxtDinner.Text = value;
                    ChkDinner.IsChecked = true;
                }
            }
        }
        bool towels, cleaning, ss;
        public bool Towels
        {
            get { return towels; }
            set
            {
                towels = value;
                ChkTowels.IsChecked = value;
            }
        }
        public bool Cleaning
        {
            get { return cleaning; }
            set
            {
                cleaning = value;
                ChkCleaning.IsChecked = value;
            }
        }
        public bool SweetestSurprise
        {
            get { return ss; }
            set
            {
                ss = value;
                ChkSweetestSurprise.IsChecked = value;
            }
        }

        #region window controls
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                Close();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
                WindowState = WindowState.Minimized;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        #endregion

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            breakfast =  ChkBreakfast.IsChecked ?? false ? TxtBreakfast.Text:string.Empty;
            lunch =  ChkLunch.IsChecked ?? false ? TxtLunch.Text:string.Empty;
            dinner =  ChkDinner.IsChecked ?? false ? TxtDinner.Text:string.Empty;

            towels = ChkTowels.IsChecked??false;
            cleaning = ChkCleaning.IsChecked??false;
            ss = ChkSweetestSurprise.IsChecked??false;

            Close();
        }


        #region Enabling and disabling text boxes
        private void ChkBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            TxtBreakfast.IsEnabled = true;
        }

        private void ChkBreakfast_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBreakfast.IsEnabled = false;
        }

        private void ChkLunch_Checked(object sender, RoutedEventArgs e)
        {
            TxtLunch.IsEnabled = true;
        }

        private void ChkLunch_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtLunch.IsEnabled = false;
        }

        private void ChkDinner_Checked(object sender, RoutedEventArgs e)
        {
            TxtDinner.IsEnabled = true;
        }

        private void ChkDinner_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtDinner.IsEnabled = false;
        }
        #endregion

        #region Placeholder
        
        private void TxtGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "Quantity?")
                {
                    tb.Text = string.Empty;
                }
            }
        }
        private void TxtLostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "Quantity?";
                }
            }
        }
        #endregion
    }
}
