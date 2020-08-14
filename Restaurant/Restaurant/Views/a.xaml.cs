using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for a.xaml
    /// </summary>
    public partial class a : Window
    {
        public byte[] photo=null;

        public a()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "PNG Files (.png)|*.png|JPEG Files (.jpeg)|*.jpeg|JPG Files (.jpg)|*.jpg|GIF Files (.gif)|*.gif";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                photo = new byte[fileStream.Length];
                fileStream.Read(photo, 0, System.Convert.ToInt32(fileStream.Length));
                fileStream.Close();
            }

            connection.Open();
            SqlCommand command = new SqlCommand("Add", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", txtnume.Text);
            command.Parameters.AddWithValue("@photo", photo);
            command.ExecuteNonQuery();
            connection.Close();
            photo = null;
            MessageBox.Show("The player is registered!", "", MessageBoxButton.OK);
        
    }
    }
}
