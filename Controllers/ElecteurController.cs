using DevoirPA.Models;
using DevoirPA.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevoirPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElecteurController : ControllerBase
    {

        private readonly devoirpaContext DBContext;

        public ElecteurController(devoirpaContext DBContext)
        {
            this.DBContext = DBContext;
        }


        // GET: api/<ElecteurController>
        [HttpGet]
        public async Task<ActionResult<List<ElecteurDTO>>> Get()
        {
            var List = await DBContext.Electeur.Select(
                s => new ElecteurDTO
                {
                    Numero = s.Numero,
                    Prenom = s.Prenom,
                    Nom = s.Nom,
                    Lieu = s.Lieu,
                    Ladate = s.Ladate,
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

         [HttpGet("{numero}")]
         public async Task<ActionResult<Electeur>> GetElecteur(string numero)
         {
            if (DBContext.Electeur == null)
            {
                return NotFound();
            }
            var electeur = await DBContext.Electeur.FindAsync(numero);
            if(electeur == null)
            {
                return NotFound();
            }

            return electeur;

         }

           // POST: api/electeurs
        [HttpPost]
        public async Task<ActionResult<Electeur>> AjouterElecteur(Electeur electeur)
        {
            DBContext.Electeur.Add(electeur);
            await DBContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetElecteur), new { numero = electeur.Numero }, electeur);
        }

        // DELETE: api/electeurs/5
        [HttpDelete("{numero}")]
        public async Task <IActionResult> DeleteElecteur(string numero)
        {
            if (DBContext.Electeur == null)
            {
                return NotFound();
            }
            var electeur = await DBContext.Electeur.FindAsync(numero);
                if (electeur == null)
                {
                    return NotFound();
                }
                DBContext.Electeur.Remove(electeur);
                await DBContext.SaveChangesAsync();
                return NoContent();

        }

    }
}
