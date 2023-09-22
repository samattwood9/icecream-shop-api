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
            
            context.Samples.Add(new api.Models.Sample{Id = "0", CreatedAt = DateTime.Now.ToString(), TestBool = true, SecondTestBool = true, FavouriteNumber = 9});
            context.Samples.Add(new api.Models.Sample{Id = "1", CreatedAt = DateTime.Now.ToString(), TestBool = false, SecondTestBool = true, FavouriteNumber = 15});
            context.Samples.Add(new api.Models.Sample{Id = "2", CreatedAt = DateTime.Now.ToString(), TestBool = true, SecondTestBool = true, FavouriteNumber = 3});
            context.Samples.Add(new api.Models.Sample{Id = "3", CreatedAt = DateTime.Now.ToString(), TestBool = false, SecondTestBool = true, FavouriteNumber = 38});
            context.Samples.Add(new api.Models.Sample{Id = "4", CreatedAt = DateTime.Now.ToString(), TestBool = true, SecondTestBool = true, FavouriteNumber = 78});
            context.Samples.Add(new api.Models.Sample{Id = "5", CreatedAt = DateTime.Now.ToString(), TestBool = null, SecondTestBool = false, FavouriteNumber = 12});
            context.Samples.Add(new api.Models.Sample{Id = "6", CreatedAt = DateTime.Now.ToString(), TestBool = null, SecondTestBool = false, FavouriteNumber = 7});
            context.Samples.Add(new api.Models.Sample{Id = "7", CreatedAt = DateTime.Now.ToString(), TestBool = false, SecondTestBool = false, FavouriteNumber = 77});
            context.Samples.Add(new api.Models.Sample{Id = "8", CreatedAt = DateTime.Now.ToString(), TestBool = false, SecondTestBool = false, FavouriteNumber = 98});
            context.Samples.Add(new api.Models.Sample{Id = "9", CreatedAt = DateTime.Now.ToString(), TestBool = true, SecondTestBool = false, FavouriteNumber = 1});

            context.SaveChanges();
        }
    }
}