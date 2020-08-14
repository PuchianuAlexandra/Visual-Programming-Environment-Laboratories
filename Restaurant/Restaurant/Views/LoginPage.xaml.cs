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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register window = new Register();
            window.ShowDialog();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtMail.Text == "" || txtPassword.Password == "" || (btnCheckCustomer.IsChecked == false && btnCheckEmployee.IsChecked == false)) 
            {
                MessageBox.Show("You have to fill all the boxes!", "", MessageBoxButton.OK);
                return;
            }
            User user = new User("","","",txtMail.Text,txtPassword.Password,"");
            if(btnCheckCustomer.IsChecked==true)
            {
                user.Status = "Customer";
                Utils.GetClient(ref user);
            }
            if (btnCheckEmployee.IsChecked == true)
            {
                user.Status = "Employee";
                Utils.GetEmployee(ref user);
            }
            if (user.Id == 0)
            {
                MessageBox.Show("You are not registered.", "", MessageBoxButton.OK);
                return;
            }
            MessageBox.Show("Login Successfully!", "", MessageBoxButton.OK);
            btnLogIn.IsEnabled = false;
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnSignIn.IsEnabled = false;
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnCart.IsEnabled = true;
            ((MainWindow)System.Windows.Application.Current.MainWindow).txtUserName.Text = user.FirstName;
            ((MainWindow)System.Windows.Application.Current.MainWindow).txtUserStatus.Text = user.Status;
            ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser = user;
            ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
            App.Current.Windows[1].Close();
        }

    }
}
