using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.ViewModel
{
    class Utils
    {
        public static void AddClient(User user)
        {
                string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("InsertClientProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstName", user.FirstName);
                command.Parameters.AddWithValue("@lastName", user.LastName);
                command.Parameters.AddWithValue("@phone", user.Phone);
                command.Parameters.AddWithValue("@mail", user.Mail);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@address", user.Address);
                command.ExecuteNonQuery();
                connection.Close();
        }

        public static void GetClient(ref User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetClientProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@mail", user.Mail);
            command.Parameters.AddWithValue("@password", user.Password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user.Id = (int)reader[0];
                user.FirstName = reader[1].ToString();
                user.LastName = reader[2].ToString();
                user.Phone = reader[3].ToString();
                user.Mail = reader[4].ToString();
                user.Password = reader[5].ToString();
                user.Address = reader[6].ToString();
            }
            connection.Close();
        }

        public static void GetEmployee(ref User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetEmployeeProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@mail", user.Mail);
            command.Parameters.AddWithValue("@password", user.Password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user.Id = (int)reader[0];
                user.FirstName = reader[1].ToString();
                user.LastName = reader[2].ToString();
                user.Phone = reader[3].ToString();
                user.Mail = reader[4].ToString();
                user.Password = reader[5].ToString();
                user.Address = reader[6].ToString();
            }
            connection.Close();
        }

        public static void GetProduct(ref Product product)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetProductProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", product.Id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                product.Id = (int)reader[0];
                product.Name = reader[1].ToString();
                product.Price = (decimal)reader[2];
                product.Quantity = (decimal)reader[3];
                product.TotalQuantity = (int)reader[4];
                product.Photo = (byte[])reader[5];
                product.IdTypeProduct = (int)reader[6];
                product.Active = (bool)reader[7];
            }
            connection.Close();
        }

        public static void GetAllProducts(ref List<Product> productsList)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetAllProductsProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product=new Product();
                product.Id = (int)reader[0];
                product.Name = reader[1].ToString();
                product.Price = (decimal)reader[2];
                product.Quantity = (decimal)reader[3];
                product.TotalQuantity = (int)reader[4];
                product.Photo = (byte[])reader[5];
                product.IdTypeProduct = (int)reader[6];
                product.Active = (bool)reader[7];
                productsList.Add(product);
            }
            connection.Close();
        }

        public static void GetProductsByCategory(List<Product> productsList, ref List<Product> productsListByCategory, int category)
        {
            foreach(Product product in productsList)
            {
                if (product.IdTypeProduct == category)
                {
                    productsListByCategory.Add(product);
                }
            }
        }

        public static void GetTotalPrice(List<Product> productsList, ref decimal totalPrice)
        {
            totalPrice = 0;
            foreach(Product product in productsList)
            {
                totalPrice += product.Price;
            }
        }

        public static void AddOrder(ref Order order)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("InsertOrderProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idClient", order.IdClient);
            command.Parameters.AddWithValue("@totalPrice", order.TotalPrice);
            command.Parameters.AddWithValue("@status", order.Status);
            command.Parameters.AddWithValue("@date", order.Date);
            command.ExecuteNonQuery();

            command = new SqlCommand("GetIdOrderProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idClient", order.IdClient);
            command.Parameters.AddWithValue("@date", order.Date);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                order.Id = (int)reader[0];
            }
            reader.Close();

            foreach (Product product in order.Products)
            {
                command = new SqlCommand("InsertOrderProductProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idOrder", order.Id);
                command.Parameters.AddWithValue("@idProduct", product.Id);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void UpdateProduct(Product product)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbRestaurantConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("UpdateTotalQuantityProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idProduct", product.Id);
            command.Parameters.AddWithValue("@totalQuantity", product.TotalQuantity);
            command.Parameters.AddWithValue("@active", product.Active);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
