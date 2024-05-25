using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Interfaces.Ingredients;
using Africuisine.Infrastructure.Persistence.Context;

namespace Africuisine.Infrastructure.Persistence.Repositories.Ingredients
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly AfricuisineDbContext DataContext;

        public MeasurementRepository(AfricuisineDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public IQueryable<Measurement> GetMeasurements()
        {
            var categories = DataContext.Measurements.AsQueryable();
            return categories;
        }
    }
}