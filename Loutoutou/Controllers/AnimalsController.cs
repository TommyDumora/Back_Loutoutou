using Microsoft.AspNetCore.Mvc;
using Loutoutou.Models;
using Loutoutou.Services;

namespace Loutoutou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ServiceLoutoutou _serviceLoutoutou;

        public AnimalsController(ServiceLoutoutou serviceLoutou)
        {
            _serviceLoutoutou = serviceLoutou;
        }

        [HttpGet]
        public async Task<ActionResult<Animals>> GetAllAnimals()
        {
            try
            {
                var animals = await _serviceLoutoutou.GetAllAnimals();
                return Ok(animals);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animals>?> GetAnimalById(int id)
        {
            try
            {
                var animal = await _serviceLoutoutou.GetAnimalById(id);
                if (animal == null)
                {
                    return null;
                } else
                {
                    return Ok(animal);
                }
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// GET: api/Animals
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Animals>>> GetAnimals()
        //{
        //  if (_context.Animals == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Animals.ToListAsync();
        //}

        //// GET: api/Animals/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Animals>> GetAnimals(int id)
        //{
        //  if (_context.Animals == null)
        //  {
        //      return NotFound();
        //  }
        //    var animals = await _context.Animals.FindAsync(id);

        //    if (animals == null)
        //    {
        //        return NotFound();
        //    }

        //    return animals;
        //}

        //// PUT: api/Animals/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnimals(int id, Animals animals)
        //{
        //    if (id != animals.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(animals).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnimalsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Animals
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Animals>> PostAnimals(Animals animals)
        //{
        //  if (_context.Animals == null)
        //  {
        //      return Problem("Entity set 'loutoutouContext.Animals'  is null.");
        //  }
        //    _context.Animals.Add(animals);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAnimals", new { id = animals.Id }, animals);
        //}

        //// DELETE: api/Animals/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnimals(int id)
        //{
        //    if (_context.Animals == null)
        //    {
        //        return NotFound();
        //    }
        //    var animals = await _context.Animals.FindAsync(id);
        //    if (animals == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Animals.Remove(animals);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnimalsExists(int id)
        //{
        //    return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
