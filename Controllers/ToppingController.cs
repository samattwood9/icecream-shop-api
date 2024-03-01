using api.Domains.Interfaces;
using api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;

namespace api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : ControllerBase
    {
        private readonly ITopping domain;

        public ToppingController(ITopping domain)
        {
            this.domain = domain;
        }

        [HttpGet(), ActionName("read-toppings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<ToppingDTO>> ReadToppings()
        {
            return domain.ReadToppings();
        }

        [HttpGet("{id}"), ActionName("read-topping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ToppingDTO> ReadTopping(int id)
        {
            return domain.ReadTopping(id);
        }

        [HttpPut(), ActionName("create-topping")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ToppingDTO> CreateTopping(ToppingDTO topping)
        {
            ToppingDTO newTopping = domain.CreateTopping(topping);
            return CreatedAtAction("create-topping", new { Id = newTopping.Id }, newTopping);
        }

        [HttpPost("{id}"), ActionName("update-topping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ToppingDTO> UpdateTopping(ToppingDTO item)
        {
            return domain.UpdateTopping(item);
        }

        [HttpDelete("{id}"), ActionName("delete-topping")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ToppingDTO> DeleteTopping(int id)
        {
            domain.DeleteTopping(id);
            return StatusCode(204);
        }
    }
}