using Hangman.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hangman
{
    class Utils
    {
        public static void choosePhoto(ref byte[] photo)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "PNG Files (.png)|*.png|JPEG Files (.jpeg)|*.jpeg|JPG Files (.jpg)|*.jpg|GIF Files (.gif)|*.gif";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if(result==true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName,FileMode.Open,FileAccess.Read);
                photo = new byte[fileStream.Length];
                fileStream.Read(photo, 0, System.Convert.ToInt32(fileStream.Length));
                fileStream.Close();
            }
        }

        public static void addPlayer(string txtName, byte[] photo)
        {
            if (string.IsNullOrEmpty(txtName) || txtName == "Write a name")
            {
                MessageBox.Show("You have to insert a name!", "ERROR", MessageBoxButton.OK);
            }
            else
            if (photo == null) 
            {
                MessageBox.Show("You have to choose a photo!", "ERROR", MessageBoxButton.OK);
            }
            else
            {
                string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("InsertProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", txtName);
                command.Parameters.AddWithValue("@photo", photo);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("The player is registered!", "", MessageBoxButton.OK);
            }
        }

        public static void getUsers(ref List<string> usersList)
        {
            string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetUsersProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                usersList.Add(reader["name"].ToString());
            }
            connection.Close();
        }

        public static void getPhoto(string name, byte[] photo,ref BitmapImage source )
        {
            string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetPhotoProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                photo = (byte[])reader["photo"];
            }
            connection.Close();

            MemoryStream stream = new MemoryStream();
            stream.Write(photo, 0, photo.Length);
            stream.Position = 0;
            source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = stream;
            source.EndInit();
        }

        public static void deleteUser(string name)
        {
            string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("DeleteUserProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("The player was deleted!", "", MessageBoxButton.OK);
        }

        public static void getWonGames(string name, ref int wonGames)
        {
           string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetWinGamesProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                wonGames = (int)reader["winGames"];
            }
            connection.Close();

           
        }

        public static void getTotalGames(string name, ref int totalGames)
        {
            string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("GetTotalGamesProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                totalGames = (int)reader["totalGames"];
            }
            connection.Close();


        }

        public static void updateGameDetails(string name, int wonGames, int totalGames)
        {
            string connectionString = Properties.Settings.Default.dbHangmanConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("UpdateGameDetailsProcedure", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@winGames", wonGames);
            command.Parameters.AddWithValue("@totalGames", totalGames);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static List<string> WordsList(string category)
        {
            List<string> words = new List<string>();

            string path = "..\\..\\" + category + ".txt";
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    words.Add(line.Split(' ')[0]);
                }
            }
            return words;
        }

        public static string GetRandomWord(List<string> words)
        {
            Random randNum = new Random();
            int aRandomPos = randNum.Next(words.Count);
            string w = words[aRandomPos];
            return w;
        }

        public static void GetHangmanImage(int wrongGuesses, ref BitmapImage source)
        {
            switch (wrongGuesses)
            {
                case 1:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm2"]));
                        break;
                    } 
                case 2:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm3"]));
                        break;
                    } 
                case 3:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm4"]));
                        break;
                    }
                case 4:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm5"]));
                        break;
                    }
                case 5:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm6"]));
                        break;
                    }
                case 6:
                    {
                        source = new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm7"]));
                        break;
                    }
                default: break;
            }
        }

        public static void CreateHiddenWord(string word,ref string hiddenWord)
        {
            for (int index = 0; index < word.Length; index++)
            {
                hiddenWord += "*";
            }
        }
    }

}
