using Africuisine.Application.Config;
using Africuisine.Application.Data.Ingredients;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Contracts.Ingredients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.API.Controllers.Ingredients
{
    public class MeasurementsController : APIBaseController
    {
        private readonly IMeasurementService MeasurementService;

        public MeasurementsController(IMeasurementService measurementService)
        {
            MeasurementService = measurementService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMeasurements()
        {
            var measurements = await MeasurementService.GetMeasurements();
            return Ok(
                new ItemsResponse<MeasurementDTO>
                {
                    Items = measurements,
                    Succeeded = measurements.Count > 0
                }
            );
        }
    }
}
