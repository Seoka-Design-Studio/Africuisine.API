using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.User;
using Africuisine.Domain.Repositories.Repository;
using Africuisine.Domain.Exceptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Africuisine.Application.Contracts;

namespace Africuisine.Application.Services.Users
{
    internal class ProfileService : IProfileService
    {
        private readonly IProfileRepository ProfileRepository;
        private readonly IMapper Mapper;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper)
        {
            ProfileRepository = profileRepository;
            Mapper = mapper;
        }

        public async Task<ProfileDTO> Add(ProfileCommand request)
        {
            var profile = Mapper.Map<Domain.Entities.Users.Profile>(request);
            profile = await ProfileRepository.Add(profile);
            return !string.IsNullOrEmpty(profile.Id) ? Mapper.Map<ProfileDTO>(profile) :
                throw new InternalServerErrorException("An error occured while attempting to add your update your profile.");
        }

        public Task<ProfileDTO> GetProfileById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileDTO> GetProfileByUserId(string id)
        {
            var profile = await ProfileRepository.Profiles.
                ProjectTo<ProfileDTO>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.UserId == id);
            return profile;
        }

        public async Task<ProfileDTO> Update(ProfileCommand request)
        {
            var profile = Mapper.Map<Domain.Entities.Users.Profile>(request);
            profile = await ProfileRepository.Update(profile);
            return Mapper.Map<ProfileDTO>(profile);
        }
    }
}
