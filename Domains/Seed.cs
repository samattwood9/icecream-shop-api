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

            context.SaveChanges();
        }
    }
}