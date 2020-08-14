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
    /// Interaction logic for PreparatePage.xaml
    /// </summary>
    public partial class PreparatePage : Page
    {
        List<Product> productList;
        public PreparatePage(List<Product> productsList)
        {
            InitializeComponent();
            this.productList = productsList;
            listProducts.ItemsSource = productsList;
            listProducts.SelectedIndex = -1;
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if(((MainWindow)System.Windows.Application.Current.MainWindow).CurrentUser.Id==0)
            {
                MessageBox.Show("You have to log in first!", "", MessageBoxButton.OK);
                return;
            }
            if (listProducts.SelectedIndex != -1)
            {
                Product product = (Product)listProducts.SelectedItem;
                Utils.GetProduct(ref product);
                ((MainWindow)System.Windows.Application.Current.MainWindow).CartProducts.Add(product);
                product.TotalQuantity--;
                if (product.TotalQuantity == 0)
                {
                    product.Active = false;
                }
                Utils.UpdateProduct(product);
                productList = new List<Product>();
                Utils.GetAllProducts(ref productList);
                List<Product> products = new List<Product>();
                products = productList;
                productList = new List<Product>();
                Utils.GetProductsByCategory(products, ref productList,product.IdTypeProduct);
                ((MainWindow)System.Windows.Application.Current.MainWindow).ProductsList = products;
                listProducts.ItemsSource = productList;
                listProducts.Items.Refresh();

            }
            else
            {
                MessageBox.Show("You have to chose a product!", "", MessageBoxButton.OK);
            }


        }
    }
}
