using Loutoutou.Context;
using Loutoutou.Models;
using Microsoft.EntityFrameworkCore;

namespace Loutoutou.Services
{
    public class ServiceLoutoutou
    {
        private readonly LoutoutouContext _context;

        public ServiceLoutoutou(LoutoutouContext context)
        {
            _context = context;
        }

        public async Task<List<Animals>> GetAllAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animals?> GetAnimalById(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return null;
            } else
            {
                return animal;
            }
        }
    }
}
