using api.DTOs;
using System.Collections.Generic;

namespace api.Domains.Interfaces
{
    public interface ICustomer
    {
        List<CustomerDTO> ReadCustomer(string email);
    }
}