using api.Domains.Interfaces;
using api.DTOs;
using api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace api.Domains
{
    public class Customer : ICustomer
    {
        private readonly string domain;

        private readonly Context context;

        private readonly ILogger logger;

        public Customer(Context _context, ILogger<Customer> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public IConfiguration Configuration { get; }

        public List<CustomerDTO> ReadCustomer(string email)
        {
            var query = $"SELECT * FROM Customers WHERE Email='{email}'";
            var customers = context.Customers.FromSqlRaw(query);

            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                var customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    Name = customer.Name,
                    Address = customer.Address,
                    FavouriteFlavour = customer.FavouriteFlavour
                };

                customerDTOs.Add(customerDTO);
            }
            
            return customerDTOs;
        }
    }
}
