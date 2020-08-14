using Hangman.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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
    public partial class GameWindow : Window
    {
        Game game;

        public GameWindow(object player)
        {
            InitializeComponent();
            User user = new User(player.ToString());
            int wonGames = 0, totalGames = 0;
            Utils.getWonGames(user.Name, ref wonGames);
            Utils.getTotalGames(user.Name, ref totalGames);
            user.WonGames = wonGames;
            user.TotalGames = totalGames;
            txtUserName.Text = "Player: " + user.Name;
            game = new Game(user);
            NewGame(game);
        }

        private void NewGame(Game game)
        {
            imgHangman.Source= new BitmapImage(new Uri(ConfigurationManager.AppSettings["hgm1"]));
            UnlockTheKeyboard();
            game.User.TotalGames++;
            game.WrongGuesses = 0;
            game.RightGuesses = 0;
            game.Word = Utils.GetRandomWord(Utils.WordsList(game.Category));
            lblWord.Content = game.Word;
            string hiddenWord = "";
            Utils.CreateHiddenWord(game.Word, ref hiddenWord);
            game.HiddenWord = hiddenWord;
            DisplayHiddenWord();
            lblCategory.Content = "Category: " + game.Category;

        }

        private void DisplayHiddenWord()
        {
            lblWord.Content = "";
            for (int index = 0; index < game.Word.Length; index++)
            {
                lblWord.Content += game.HiddenWord[index].ToString();
                lblWord.Content += " ";
            }
        }

        private void MarkTheMistake()
        {
            game.WrongGuesses++;
            BitmapImage source = new BitmapImage();
            if (game.WrongGuesses < 7)
            {
                Utils.GetHangmanImage(game.WrongGuesses, ref source);
                imgHangman.Source = source;
            }
            else
            {
                LockTheKeyboard();
                lblWord.Content = game.Word;
                MessageBox.Show("You Lose!", ":(", MessageBoxButton.OK);
            }
        }

        private void UpdateHiddenWord(char letter )
        {
            for (int i = 0; i < game.Word.Length; i++)
            {
                if (game.Word.ToUpper()[i] == letter)
                {
                    StringBuilder newWord = new StringBuilder(game.HiddenWord);
                    newWord[i] = letter;
                    game.HiddenWord = newWord.ToString();

                    DisplayHiddenWord();
                    game.RightGuesses++;
                }
            }

            if(game.RightGuesses==game.Word.Length)
            {
                LockTheKeyboard();
                game.User.WonGames++;
                MessageBox.Show("You Win!", "<3", MessageBoxButton.OK);
            }
        }

        private void LockTheKeyboard()
        {
            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> frameworkElements = element.Cast<FrameworkElement>().ToList();
            var lstControl = frameworkElements.OfType<Button>();
            foreach (Button btn in lstControl)
            {
                btn.IsEnabled = false;
            }
        }
    
        private void UnlockTheKeyboard()
        {
            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> frameworkElements = element.Cast<FrameworkElement>().ToList();
            var lstControl = frameworkElements.OfType<Button>();
            foreach(Button btn in lstControl)
            {
                btn.IsEnabled = true;
            }
        }

        private void MenuItemNewGame(object sender, RoutedEventArgs e)
        {
            NewGame(game);
        }
        
        private void MenuItemStatistics(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(game.User.Name + " won: " + game.User.WonGames + "/" + game.User.TotalGames, "", MessageBoxButton.OK);
        }

        private void MenuItemExit(object sender, RoutedEventArgs e)
        {
            Utils.updateGameDetails(game.User.Name, game.User.WonGames, game.User.TotalGames);
            Logging window = new Logging();
            this.Close();
            window.Show();
        }

        private void SetAllCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "All";
            NewGame(game);
        }

        private void SetCarsCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "Cars";
            NewGame(game);
        }

        private void SetAnimalsCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "Animals";
            NewGame(game);
        }

        private void SetStatesCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "States";
            NewGame(game);
        }

        private void SetFruitsCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "Fruits";
            NewGame(game);
        }

        private void SetRiversCategories(object sender, RoutedEventArgs e)
        {
            game.Category = "Rivers";
            NewGame(game);
        }

        private void MenuItemAbout(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nume: Puchianu Alexandra-Georgian" + "\n" + "Grupa: 10LF283" + "\n" + "Specializare: Informatica", "", MessageBoxButton.OK);
        }

        private void btnLetter_Click(object sender, RoutedEventArgs e)
        {
            Button btnCurrent = sender as Button;
            btnCurrent.IsEnabled = false;

            if (game.Word.ToUpper().Contains(btnCurrent.Content.ToString()))
            {
                UpdateHiddenWord(btnCurrent.Content.ToString()[0]);
            }
            else
            {
                MarkTheMistake();
            }
        }
    }
}
