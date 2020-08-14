using Restaurant.Models;
using Restaurant.ViewModel;
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

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSingUp_Click(object sender, RoutedEventArgs e)
        {
            foreach(TextBox textBox in panel.Children.OfType<TextBox>())
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("You have to fill all the boxes!", "", MessageBoxButton.OK);
                    return;
                }
            }
            if (txtPassword.Password == "")
            {
                MessageBox.Show("You have to fill all the boxes!", "", MessageBoxButton.OK);
                return;
            }
            User user = new User(txtFirstName.Text,txtLastName.Text,txtPhoneNr.Text,txtMail.Text, txtPassword.Password,txtAddress.Text);
            Utils.AddClient(user);
            MessageBox.Show("You are now registered.", "", MessageBoxButton.OK);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
