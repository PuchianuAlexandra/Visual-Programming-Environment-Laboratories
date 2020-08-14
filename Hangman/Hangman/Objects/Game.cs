using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Objects
{
    class Game
    {
        private string word;
        private string category;
        private string hiddenWord;
        private User user;
        private int wrongGuesses;
        private int rightGuesses;

        public Game(User newUser)
        {
            word = "";
            category = "All";
            hiddenWord = "";
            user = newUser;
            wrongGuesses = 0;
            rightGuesses = 0;
        }

        public string Word
        {
            get
            {
                return word;
            }

            set
            {
                word = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public string HiddenWord
        {
            get
            {
                return hiddenWord;
            }

            set
            {
                hiddenWord = value;
            }
        }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public int WrongGuesses
        {
            get
            {
                return wrongGuesses;
            }

            set
            {
                wrongGuesses = value;
            }
        }
        
        public int RightGuesses
        {
            get
            {
                return rightGuesses;
            }

            set
            {
                rightGuesses = value;
            }
        }

    }
}
