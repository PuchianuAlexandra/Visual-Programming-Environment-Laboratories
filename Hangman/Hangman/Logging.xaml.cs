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

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Logging : Window
    {
        public Logging()
        {
            InitializeComponent();
            List<string> usersList = new List<string>();
            Utils.getUsers(ref usersList);
            listOfUsers.ItemsSource = usersList;
            btnDeleteUser.IsEnabled = false;
            btnPlay.IsEnabled = false;
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser();
            window.ShowDialog();
            List<string> usersList = new List<string>();
            Utils.getUsers(ref usersList);
            listOfUsers.ItemsSource = usersList;
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string name = listOfUsers.SelectedItem.ToString();
            Utils.deleteUser(name);
            listOfUsers.SelectedIndex = -1;
            List<string> usersList = new List<string>();
            Utils.getUsers(ref usersList);
            listOfUsers.ItemsSource = usersList;
            btnDeleteUser.IsEnabled = false;
            btnPlay.IsEnabled = false;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            GameWindow window = new GameWindow(listOfUsers.SelectedItem);
            this.Close();
            window.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listOfUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOfUsers.SelectedIndex != -1)
            {
                btnDeleteUser.IsEnabled = true;
                btnPlay.IsEnabled = true;
                string name = listOfUsers.SelectedItem.ToString();
                byte[] photo = null;
                BitmapImage source = new BitmapImage();
                Utils.getPhoto(name, photo, ref source);
                imgUser.Source = source;
            }
        }
    }
}
