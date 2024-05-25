using Africuisine.Domain.Entities.Ingredients;

namespace Africuisine.Domain.Interfaces.Ingredients
{
    public interface IMeasurementRepository
    {
        IQueryable<Measurement> GetMeasurements();
    }
}