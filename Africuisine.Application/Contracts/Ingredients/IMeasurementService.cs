using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Contracts.Ingredients
{
    public interface IMeasurementService
    {
        Task<List<MeasurementDTO>> GetMeasurements();
    }
}