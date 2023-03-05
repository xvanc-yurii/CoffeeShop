using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Entities
{
    public class CoffeeStore
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
