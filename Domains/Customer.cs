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

        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = new Models.Customer
            {
                Email = customerDTO.Email,
                Name = customerDTO.Name,
                Address = customerDTO.Address,
                FavouriteFlavour = customerDTO.FavouriteFlavour,
                AmountSpent = customerDTO.AmountSpent
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            return new CustomerDTO
            {
                Id = customer.Id,
                Email = customer.Email,
                Name = customer.Name,
                Address = customer.Address,
                FavouriteFlavour = customer.FavouriteFlavour,
                AmountSpent = customerDTO.AmountSpent
            };
        }

        public List<CustomerDTO> ReadCustomers()
        {
            var customers = context.Customers;

            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();
            foreach (var customer in customers)
            {
                var customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    Email = customer.Email,
                    Name = customer.Name,
                    Address = customer.Address,
                    FavouriteFlavour = customer.FavouriteFlavour,
                    AmountSpent = customer.AmountSpent
                };

                customerDTOs.Add(customerDTO);
            }
            
            return customerDTOs;
        }

        public List<CustomerDTO> ReadCustomer(string email)
        {
            var query = $"SELECT * FROM Customers WHERE Id='{email}'";
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
                    FavouriteFlavour = customer.FavouriteFlavour,
                    AmountSpent = customer.AmountSpent
                };

                customerDTOs.Add(customerDTO);
            }
            
            return customerDTOs;
        }
    }
}
