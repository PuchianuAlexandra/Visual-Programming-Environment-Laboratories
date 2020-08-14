using Restaurant.Models;
using Restaurant.ViewModel;
using Restaurant.Views;
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

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser = new User();
        internal User CurrentUser { get => currentUser; set => currentUser = value; }
        private List<Product> productsList = new List<Product>();
        internal List<Product> ProductsList { get => productsList; set => productsList = value; }
        private List<Product> cartProducts = new List<Product>();
        internal List<Product> CartProducts { get => cartProducts; set => cartProducts = value; }

        public MainWindow()
        {
            InitializeComponent();
            btnCart.IsEnabled = false;
            Utils.GetAllProducts(ref productsList);
        }

        private void MenuItemHome_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "ACASA";
            ImageBrush imageBrush = new ImageBrush();
            BitmapImage bitmap = new BitmapImage(new Uri("pack://application:,,,/Restaurant;component/Images/restaurant.jpg"));
            imageBrush.ImageSource = bitmap;
            MainFrame.Content = null;
            MainFrame.Background = imageBrush ;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginPage();
            txtTitle.Text = "Sign In";
        }


        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser = new User();
            txtUserName.Text = CurrentUser.FirstName;
            txtUserStatus.Text = CurrentUser.Status;
            btnCart.IsEnabled = false;
            btnSignIn.IsEnabled = true;
        }
        
        private void MenuItemPizza_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productsListByCategory = new List<Product>();
            Utils.GetProductsByCategory(productsList, ref productsListByCategory, 1);
            MainFrame.Content = new PreparatePage(productsListByCategory);
            txtTitle.Text = "Pizza";
        }
        
        private void MenuItemPaste_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productsListByCategory = new List<Product>();
            Utils.GetProductsByCategory(productsList, ref productsListByCategory, 2);
            MainFrame.Content = new PreparatePage(productsListByCategory);
            txtTitle.Text = "Paste";
        }
        
        private void MenuItemSalad_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productsListByCategory = new List<Product>();
            Utils.GetProductsByCategory(productsList, ref productsListByCategory, 3);
            MainFrame.Content = new PreparatePage(productsListByCategory);
            txtTitle.Text = "Salate";
        }

        private void MenuItemDesert_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productsListByCategory = new List<Product>();
            Utils.GetProductsByCategory(productsList, ref productsListByCategory, 4);
            MainFrame.Content = new PreparatePage(productsListByCategory);
            txtTitle.Text = "Deserturi";
        }

        private void MenuItemDrink_Click(object sender, RoutedEventArgs e)
        {
            List<Product> productsListByCategory = new List<Product>();
            Utils.GetProductsByCategory(productsList, ref productsListByCategory, 5);
            MainFrame.Content = new PreparatePage(productsListByCategory);
            txtTitle.Text = "Bauturi";
        }

        private void MenuItemCart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CartPage();
            txtTitle.Text = "Cosul meu";
        }
    }
}
