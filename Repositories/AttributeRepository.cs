using ApiAchei.Data;
using ApiAchei.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAchei.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly AppDbContext _context;

        public AttributeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Attribute>> GetAllAsync() =>
            await _context.Attributes.Include(a => a.Product).ToListAsync();

        public async Task<Models.Attribute> GetByIdAsync(int id) =>
            await _context.Attributes.FindAsync(id);

        public async Task AddAsync(Models.Attribute attribute)
        {
            await _context.Attributes.AddAsync(attribute);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Models.Attribute attribute)
        {
            _context.Entry(attribute).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attribute = await GetByIdAsync(id);
            if (attribute != null)
            {
                _context.Attributes.Remove(attribute);
                await _context.SaveChangesAsync();
            }
        }
    }
}
