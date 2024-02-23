using api.Domains.Interfaces;
using api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;

namespace api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer domain;

        public CustomerController(ICustomer domain)
        {
            this.domain = domain;
        }

        [HttpPost, ActionName("create-customer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerDTO> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            return domain.CreateCustomer(customerDTO);
        }

        [HttpGet("{email}"), ActionName("read-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CustomerDTO>> ReadCustomer(string email)
        {
            return domain.ReadCustomer(email);
        }
    }
}