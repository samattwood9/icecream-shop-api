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

        [HttpGet("{id}"), ActionName("read-customer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<CustomerDTO>> ReadCustomer(int id)
        {
            return domain.ReadCustomer(id);
        }
    }
}