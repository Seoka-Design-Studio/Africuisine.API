using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Repositories.Repository;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Repositories.Users
{
    public class CulturalGroupRepository : ICulturalGroupRepository
    {
        private readonly UserDbContext DataContext;

        public CulturalGroupRepository(UserDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<CulturalGroup> GetCulturalGroupById(string id)
        {
             var group = await DataContext.CulturalGroups.FirstOrDefaultAsync(c => c.Id == id);
             return group;
        }

        public async Task<List<CulturalGroup>> GetCulturalGroups(string id)
        {
             var groups = await DataContext.CulturalGroups.ToListAsync();
             return groups;
        }
    }
}