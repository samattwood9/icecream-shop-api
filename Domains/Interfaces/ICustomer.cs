using api.DTOs;
using System.Collections.Generic;

namespace api.Domains.Interfaces
{
    public interface ICustomer
    {
        CustomerDTO CreateCustomer(CustomerDTO customerDTO);
        List<CustomerDTO> ReadCustomer(string email);
    }
}