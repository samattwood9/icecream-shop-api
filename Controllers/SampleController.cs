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
    public class SampleController : ControllerBase
    {

        private readonly ISample domain;

        public SampleController(ISample domain)
        {
            this.domain = domain;
        }

        //Retrieve a list of all Sample items
        [HttpGet(), ActionName("read-all-items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<SampleDTO>> ReadItems()
        {
            return domain.ReadItems();
        }


        //Retrieve a single Sample item by ID
        [HttpGet("{id}"), ActionName("read-item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SampleDTO> ReadItem(string id)
        {
            return domain.ReadItem(id);
        }

        //Add a new Sample item
        [HttpPut(), ActionName("add-item")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<SampleDTO> AddItem(SampleDTO item)
        {
            SampleDTO addedItem = domain.AddItem(item);
            return CreatedAtAction("add-item", new { Id = addedItem.Id }, addedItem);

        }

        //Edit a sample item, using the updated item as a parameter (the item's ID will be retrieved from the updated item)
        [HttpPost("{id}"), ActionName("update-item")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SampleDTO> EditItem(SampleDTO item)
        {
            return domain.EditItem(item);
        }

        //Delete a Sample item by ID
        [HttpDelete("{id}"), ActionName("delete-item")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<SampleDTO> DeleteItem(string id)
        {
            domain.DeleteItem(id);
            return StatusCode(204);
        }
    }
}