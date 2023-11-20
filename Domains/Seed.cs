using api.Domains.Interfaces;
using api.Models;
using Microsoft.Extensions.Logging;
using System;

namespace api.Domains
{
    public class Seed : ISeed
    {
        private readonly Context context;
        private readonly ILogger logger;

        public Seed(Context _context, ILogger<Seed> _logger)
        {
            // Injecting the context like this implictly shares instances via DI
            // For details, see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
            context = _context;
            logger = _logger;
        }

        //Method populates the database with sample data - useful for scenarios in which local storage is being used, and data is required for demonstration purposes
        public void SeedData()
        {
            
            context.Flavours.Add(new api.Models.Flavour{Id = 1, CreatedAt = DateTime.Now.ToString(), Name = "Vanilla"});
            context.Flavours.Add(new api.Models.Flavour{Id = 2, CreatedAt = DateTime.Now.ToString(), Name = "Chocolate"});
            context.Flavours.Add(new api.Models.Flavour{Id = 3, CreatedAt = DateTime.Now.ToString(), Name = "Mint"});
            context.Flavours.Add(new api.Models.Flavour{Id = 4, CreatedAt = DateTime.Now.ToString(), Name = "Stawberry"});
            context.Flavours.Add(new api.Models.Flavour{Id = 5, CreatedAt = DateTime.Now.ToString(), Name = "Rum & raisin"});

            context.Customers.Add(new api.Models.Customer{Id = 1, Email="sama9@big-bank-123.com", Name="Sam", Address="Flat 1, New Street", FavouriteFlavour="Vanilla"});
            context.Customers.Add(new api.Models.Customer{Id = 2, Email="alice10@big-bank-123.com", Name="Alice", Address="Flat 12, Old Road", FavouriteFlavour="Chocolate"});
            context.Customers.Add(new api.Models.Customer{Id = 3, Email="mo@bigger-bank-123.com", Name="Mo", Address="Flat 123, Middle Av.", FavouriteFlavour="Mint"});
            context.Customers.Add(new api.Models.Customer{Id = 4, Email="packaging@dunder-mifflin-23.com", Name="Daryl", Address="Scranton", FavouriteFlavour="Strawberry"});
            context.Customers.Add(new api.Models.Customer{Id = 5, Email="bob@bobs-site.co.uk", Name="Paul", Address="99 Little Lane", FavouriteFlavour="Rum & raisin"});

            context.SaveChanges();
        }
    }
}