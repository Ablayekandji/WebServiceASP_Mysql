using Microsoft.AspNetCore.Mvc;
using DevoirPA.Models;
using DevoirPA.Entities;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoirPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BureauController : ControllerBase
    {

        private readonly devoirpaContext DBContext;

        public BureauController(devoirpaContext DBContext)
        {
            this.DBContext = DBContext;
        }
        // GET: api/<BureauController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bureau>>> GetBureaux()
        {
            if (DBContext.Bureau == null)
            {
                return NotFound();
            }
            return await DBContext.Bureau.ToListAsync();
        }

        // GET api/<BureauController>/5
        [HttpGet("{numero}")]
        public async Task<ActionResult<Bureau>> GetBureau(int numero)
        {
            if (DBContext.Bureau == null)
            {
                return NotFound();
            }
            var bureau = await DBContext.Bureau.FindAsync(numero);
            if (bureau == null)
            {
                return NotFound();
            }

            return bureau;

        }

        // POST api/<BureauController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BureauController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BureauController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
