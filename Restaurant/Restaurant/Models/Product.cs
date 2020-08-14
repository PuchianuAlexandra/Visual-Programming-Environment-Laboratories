using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Quantity { get; set; }
        
        public int TotalQuantity { get; set; }
        
        public byte[] Photo { get; set; }
        
        public int IdTypeProduct { get; set; }
        
        public bool Active { get; set; }

        public Product()
        {
            Id = 0;
            Name = "";
            Price = 0;
            Quantity = 0;
            TotalQuantity = 0;
            Photo = null;
            IdTypeProduct = 0;
            Active = false;
        }

        public Product(int id, string name, decimal price, decimal quantity, int totalQuantity, byte[] photo, int idTypeProduct, bool active)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            TotalQuantity = totalQuantity;
            Photo = photo;
            IdTypeProduct = idTypeProduct;
            Active = active;
        }
    }
}
