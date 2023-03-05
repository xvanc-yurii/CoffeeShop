using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Entities;

namespace CoffeeShop.Contexts
{
    public interface IContext<T> where T : CoffeeChecks
    {
        void Create(CoffeeChecks entity);
        void Update(CoffeeChecks entity);
        void Delete(Guid id);
        void Delete(CoffeeChecks entity);


        IEnumerable<CoffeeChecks> GetAll();
    }
}
