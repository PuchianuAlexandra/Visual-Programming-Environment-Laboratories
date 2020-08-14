using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Objects
{
    class User
    {
        private string name;
        private int wonGames;
        private int totalGames;

        public User(string userName)
        {
            name = userName;
            wonGames = 0;
            totalGames = 0;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int WonGames
        {
            get
            {
                return wonGames;
            }

            set
            {
                wonGames = value;
            }
        }

        public int TotalGames
        {
            get
            {
                return totalGames;
            }

            set
            {
                totalGames = value;
            }
        }
    }
}
