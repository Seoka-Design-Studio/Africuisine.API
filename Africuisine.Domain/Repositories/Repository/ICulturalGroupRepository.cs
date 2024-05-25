using Africuisine.Domain.Entities.User;

namespace Africuisine.Domain.Repositories.Repository
{
    public interface ICulturalGroupRepository
    {
        Task<CulturalGroup> GetCulturalGroupById(string id);
        Task<List<CulturalGroup>> GetCulturalGroups(string id);
    }
}