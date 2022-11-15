using Microsoft.AspNetCore.Mvc;
using DevoirPA.Models;
using DevoirPA.Entities;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoirPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreController : ControllerBase
    {

        private readonly devoirpaContext DBContext;

        public CentreController(devoirpaContext DBContext)
        {
            this.DBContext = DBContext;
        }
        // GET: api/<CentreController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centre>>> GetBureaux()
        {
            if (DBContext.Centre == null)
            {
                return NotFound();
            }
            return await DBContext.Centre.ToListAsync();
        }

        // GET api/<CentreController>/5
        [HttpGet("{nuumero}")]
        public async Task<ActionResult<Centre>> GetCentre(int nuumero)
        {
            if (DBContext.Centre == null)
            {
                return NotFound();
            }
            var centre = await DBContext.Centre.FindAsync(nuumero);
            if (centre == null)
            {
                return NotFound();
            }

            return centre;

        }

        // POST api/<CentreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CentreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CentreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
