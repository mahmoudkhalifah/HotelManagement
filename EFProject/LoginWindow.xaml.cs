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

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(sender is TextBox tb)
            {
                /*if(tb.Text==string.Empty)
                {
                    tb.Text = "username";
                    tb.SelectAll();
                }*/
            }
        }

        private void txtUsername_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
