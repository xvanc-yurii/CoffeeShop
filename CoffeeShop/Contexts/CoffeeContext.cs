using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Entities;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoffeeShop.Contexts
{
    public class CoffeeContext : IContext<CoffeeChecks> 
    {
        private string _fileName = "Checks.json"; // Название файла
        private List<CoffeeChecks>? _checks; // список пользователей

        public CoffeeContext()
        {
            if (!File.Exists(_fileName))
                File.Create(_fileName);

            var reader = new StreamReader(_fileName);
            string fileContent = reader.ReadToEnd();
            reader.Close();

            if (fileContent.Length < 2)
            {
                _checks = new List<CoffeeChecks>();
            }
            else
            {
                _checks = JsonSerializer.Deserialize<List<CoffeeChecks>>(fileContent);
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(_checks);

            var writer = new StreamWriter(_fileName);
            writer.Write(json);
            writer.Close();
        }

        public void Create(CoffeeChecks entity)
        {
            _checks.Add(entity);
        }

        public void Delete(Guid id)
        {
            _checks.RemoveAll(check => check.Id == id);
        }

        public void Delete(CoffeeChecks entity)
        {
            Delete(entity.Id);
        }

        public IEnumerable<CoffeeChecks> GetAll()
        {
            return _checks;
        }

        public void Update(CoffeeChecks entity)
        {
            var check = _checks.FirstOrDefault(check => check.Id == entity.Id);

            if (check is null)
                throw new ArgumentException("Update error. Check not found");

            check.Name = entity.Name;
            check.Price = entity.Price;
            check.CountOfItems = entity.CountOfItems;
        }

        public void SortByPrice()
        {
            for(int i = 0; i < _checks.Count(); i++)
            {
                for(int j = 0; j<_checks.Count()-1-i; j++)
                {
                    if (_checks[j].Price > _checks[j + 1].Price)
                    {
                        CoffeeChecks temp = _checks[j + 1];
                        _checks[j + 1] = _checks[j];
                        _checks[j] = temp;
                    }
                }
            }
        }

        public void SortByDate()
        {
            for (int i = 0; i < _checks.Count(); i++)
            {
                for (int j = 0; j<_checks.Count()-1-i; j++)
                {
                    if (_checks[j].CreateAt > _checks[j + 1].CreateAt)
                    {
                        CoffeeChecks temp = _checks[j + 1];
                        _checks[j + 1] = _checks[j];
                        _checks[j] = temp;
                    }
                }
            }
        }

        public double GetAllMoney()
        {
            double Sum = 0;
            foreach(CoffeeChecks check in _checks)
            {
                Sum+= check.Price;
            }
            return Sum;
        }
    }


}
