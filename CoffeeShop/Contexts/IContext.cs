using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Entities;

namespace CoffeeShop.Contexts
{
    public interface IContext
    {
        void Create(CoffeeStore entity);
        void Update(CoffeeStore entity);
        void Delete(CoffeeStore entity);
        
        IEnumerable<CoffeeStore> GetAll();
    }
}
