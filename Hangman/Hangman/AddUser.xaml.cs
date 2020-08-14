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
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        byte[] photo = null;

        private void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            Utils.choosePhoto(ref photo);
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            Utils.addPlayer(txtName.Text, photo);
            photo = null;
            this.Close();
        }

        private void txtName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(txtName.Text== "Write a name")
            {
                txtName.Text = "";
            }
        }
    }
}
