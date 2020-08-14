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
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
            txtFirstName.Text = txtFirstName.Text + " " + ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.FirstName;
            txtLastName.Text = txtLastName.Text + " " + ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.LastName;
            txtPhone.Text = txtPhone.Text + " " + ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.Phone;
            txtAddress.Text = txtAddress.Text + " " + ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.Address;
            listProducts.ItemsSource = ((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts;
            decimal totalPrice=0;
            Utils.GetTotalPrice(((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts, ref totalPrice);
            txtTotalPrice.Text = "Total: "+totalPrice.ToString();
            listProducts.SelectedIndex = -1;
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (listProducts.SelectedIndex != -1)
            {
                Product product = (Product)listProducts.SelectedItem;
                Utils.GetProduct(ref product);
                ((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts.Remove(product);
                listProducts.ItemsSource = ((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts;
                listProducts.Items.Refresh();
                decimal totalPrice = 0;
                Utils.GetTotalPrice(((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts, ref totalPrice);
                txtTotalPrice.Text = "Total: " + totalPrice.ToString();
                product.TotalQuantity++;
                product.Active = true;
                Utils.UpdateProduct(product);
                List<Product> newProducts=new List<Product>();
                Utils.GetAllProducts(ref newProducts);
                ((MainWindow)System.Windows.Application.Current.MainWindow).ProductsList = newProducts;
            }
            else
            {
                MessageBox.Show("You have to chose a product!", "", MessageBoxButton.OK);
            }
            
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.IdClient = ((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.Id;
            decimal totalPrice=0;
            Utils.GetTotalPrice(((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts, ref totalPrice);
            order.TotalPrice = totalPrice;
            order.Products = ((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts;
            Utils.AddOrder(ref order);
            MessageBox.Show("Order Placed!", "", MessageBoxButton.OK);
        }
    }
}
