using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        public string Mail { get; set; }
        
        public string Password { get; set; }
        
        public string Address { get; set; }
        
        public string Status { get; set; }
        
        public User()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Phone = "";
            Mail = "";
            Password = "";
            Address = "";
            Status = "";
        }

        public User(string firstName, string lastName, string phone, string mail, string password, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Mail = mail;
            Password = password;
            Address = address;
        }
    }
}
