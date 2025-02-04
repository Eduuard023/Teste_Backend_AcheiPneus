using ApiAchei.Models;

namespace ApiAchei.Repositories
{
    public interface IAttributeRepository
    {
        Task<IEnumerable<Models.Attribute>> GetAllAsync();
        Task<Models.Attribute> GetByIdAsync(int id);
        Task AddAsync(Models.Attribute attribute);
        Task UpdateAsync(Models.Attribute attribute);
        Task DeleteAsync(int id);
    }
}
