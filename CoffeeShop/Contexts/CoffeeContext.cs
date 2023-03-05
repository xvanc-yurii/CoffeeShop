using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Entities;
using System.Text.Json;

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
            check.Count = entity.Count;
        }
    }


}
