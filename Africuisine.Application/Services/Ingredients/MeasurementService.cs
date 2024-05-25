using Africuisine.Application.Data.Ingredients;
using Africuisine.Application.Contracts.Ingredients;
using Africuisine.Domain.Interfaces.Ingredients;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Africuisine.Domain.Exceptions;

namespace Africuisine.Application.Services.Ingredients
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository MeasurementRepository;
        private readonly IMapper Mapper;

        public MeasurementService(IMeasurementRepository measurementRepository, IMapper mapper)
        {
            MeasurementRepository = measurementRepository;
            Mapper = mapper;
        }

        public async Task<List<MeasurementDTO>> GetMeasurements()
        {
            var measurements = await MeasurementRepository.GetMeasurements()
            .ProjectTo<MeasurementDTO>(Mapper.ConfigurationProvider).ToListAsync();
            return measurements.Count > 0 ? measurements : throw new NotFoundException("Ingredient measurements records could not be found in the application.");
        }
    }
}