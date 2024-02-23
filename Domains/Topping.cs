using api.Domains.Interfaces;
using api.DTOs;
using api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace api.Domains
{
    public class Topping : ITopping
    {
        private readonly Context context;
        private readonly ILogger logger;

        public Topping(Context _context, ILogger<Topping> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public List<ToppingDTO> ReadToppings()
        {
            List<ToppingDTO> toppings = new List<ToppingDTO>();

            foreach (Models.Topping topping in context.Toppings)
            {
                toppings.Add(new ToppingDTO
                {
                    Id = topping.Id,
                    Name = topping.Name,
                    Price = topping.Price
                });
            }

            return toppings;
        }

        public ToppingDTO ReadTopping(int id)
        {
            Models.Topping topping = context.Toppings.Where(s => s.Id == id).SingleOrDefault();

            return new ToppingDTO
            {
                Id = topping.Id,
                Name = topping.Name,
                Price = topping.Price
            };
        }

        public ToppingDTO CreateTopping(ToppingDTO newTopping)
        {
            Models.Topping topping = new Models.Topping { Name = newTopping.Name, Price = newTopping.Price};

            context.Toppings.Add(topping);
            context.SaveChanges();

            return new ToppingDTO
            {
                Id = topping.Id,
                Name = topping.Name,
                Price = topping.Price
            };
        }

        public ToppingDTO UpdateTopping(ToppingDTO updatedTopping)
        {
            Models.Topping topping = context.Toppings.Where(s => s.Id == updatedTopping.Id).SingleOrDefault();

            topping.Name = updatedTopping.Name;
            context.SaveChanges();

            return new ToppingDTO
            {
                Id = topping.Id,
                Name = topping.Name,
                Price = topping.Price
            };
        }

        public void DeleteTopping(int id)
        {
            Models.Topping topping = context.Toppings.Where(s => s.Id == id).SingleOrDefault();
            context.Toppings.Remove(topping);
            context.SaveChanges();
        }
    }
}
