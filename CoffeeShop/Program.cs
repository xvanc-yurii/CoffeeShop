using CoffeeShop.Contexts;
using CoffeeShop.Entities;

var context = new CoffeeContext();

context.Create(new CoffeeChecks 
{
    Name = "Amerikano 175ml",
    Price = 20,
    Count = 1,
});
context.Create(new CoffeeChecks
{
    Name = "Flet Uait",
    Price = 80,
    Count = 2
});
context.Create(new CoffeeChecks
{
    Name = "Late 400ml",
    Price = 40,
    Count = 1
});

context.Save();