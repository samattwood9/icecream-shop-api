using api.Domains.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ISeed domain;

        public SeedController(ISeed domain)
        {
            this.domain = domain;
        }

        // SPECIAL ENDPOINT FOR SEEDING DATA
        [HttpPut, ActionName("seed-data")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult Seed()
        {
            domain.SeedData();

            return Ok();
        }
    }
}