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
    public class FlavourController : ControllerBase
    {

        private readonly IFlavour domain;

        public FlavourController(IFlavour domain)
        {
            this.domain = domain;
        }

        [HttpGet(), ActionName("read-flavours")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<FlavourDTO>> ReadFlavours()
        {
            return domain.ReadFlavours();
        }

        [HttpGet("{id}"), ActionName("read-flavour")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FlavourDTO> ReadFlavour(int id)
        {
            return domain.ReadFlavour(id);
        }

        [HttpPut(), ActionName("create-flavour")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<FlavourDTO> CreatFlavour(FlavourDTO flavour)
        {
            FlavourDTO newFlavour = domain.CreateFlavour(flavour);
            return CreatedAtAction("create-flavour", new { Id = newFlavour.Id }, newFlavour);
        }

        [HttpPost("{id}"), ActionName("update-flavour")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FlavourDTO> UpdateFlavour(FlavourDTO item)
        {
            return domain.UpdateFlavour(item);
        }

        [HttpDelete("{id}"), ActionName("delete-flavour")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<FlavourDTO> DeleteFlavour(int id)
        {
            domain.DeleteFlavour(id);
            return StatusCode(204);
        }
    }
}