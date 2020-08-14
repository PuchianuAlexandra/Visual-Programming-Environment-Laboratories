using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    class Order
    {
        public int Id { get; set; }
       
        public int IdClient { get; set; }

        public decimal TotalPrice { get; set; }
        
        public string Status { get; set; }
        
        public DateTime Date { get; set; }

        public List<Product> Products { get; set; }

        public Order()
        {
            Id = 0;
            IdClient = 0;
            TotalPrice = 0;
            Status = "In Progress";
            Date = DateTime.Now;
            Products = new List<Product>();
        }
    }
}
