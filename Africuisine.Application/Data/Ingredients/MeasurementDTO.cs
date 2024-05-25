using Africuisine.Application.Data;

namespace Africuisine.Application.Data.Ingredients
{
    public class MeasurementDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
    }
}