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
using System.Windows.Shapes;

namespace DialogsUI
{
    /// <summary>
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {

        string exp;
        public string CVV { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string Exp
        {
            get { return exp; }
            set
            { 
                exp = value;
                CmbMM.Text = exp.Split("/")[0];
                CmbYY.Text = exp.Split("/")[1];
            }
        }

        public float foodBill { get; set; }
        public float roomBill { get; set; }
        public float TotalBill { get; set; }
        public float Taxes { get; set; }



        public Bill(int _rbill,float _fbill)
        {
            InitializeComponent();
            roomBill = _rbill;
            foodBill = _fbill;
            CmbCardType.ItemsSource = new string[] { "Discover","Visa","MasterCard","Unknown" };
            List<string> months= new List<string>(12);
            List<string> years= new List<string>(10);

            for(int i=1;i<=12;i++)
            {
                months.Add(i.ToString().Length > 1 ? i.ToString() : new StringBuilder().Append('0').Append(i).ToString());
            }
            for (int i = 23; i <= 33; i++)
            {
                years.Add(i.ToString());
            }

            CmbMM.ItemsSource = months;
            CmbYY.ItemsSource = years;
            LblFoodBill.Content = _fbill;
            LblCurrentBill.Content = _rbill;
            Taxes = (int)(_fbill+_rbill * 0.14);
            LblTaxPrice.Content = Taxes;
            TotalBill = _rbill + _fbill + Taxes;
            LblTotalPrice.Content = TotalBill;
        }

        #region Window Controls
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

        #region PlaceHololders
        private void TxtCardNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "9999 - 9999 - 9999 - 9999")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtCardNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "9999 - 9999 - 9999 - 9999";
                }
            }
        }

        private void TxtCVV_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == "CVV")
                {
                    tb.Text = string.Empty;
                }
            }
        }

        private void TxtCVV_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text == string.Empty)
                {
                    tb.Text = "CVV";
                }
            }
        }

        #endregion

        private void CmbCardType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LblCardType.Content = CmbCardType.SelectedValue;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            CVV = TxtCVV.Text;
            CardNumber = TxtCardNumber.Text;
            Exp = CmbMM.Text + "/" + CmbYY.Text;
            CardType = (string)CmbCardType.SelectedValue;

            Close();
        }
    }

}