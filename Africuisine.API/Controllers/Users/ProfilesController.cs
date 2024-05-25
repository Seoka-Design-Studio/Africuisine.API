using Africuisine.Application.Config;
using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Africuisine.Application.Data.User;
using System.Text.Json;
using Africuisine.Domain.Repositories.Services;
using Africuisine.Application.Contracts;

namespace Africuisine.API.Controllers.Users
{
    public class ProfilesController : APIBaseController
    {
        private IProfileService ProfileService { get; set; }
        private readonly IFileService FileService;
        public ProfilesController(IProfileService profileService, IFileService fileService)
        {
            ProfileService = profileService;
            FileService = fileService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromForm] ProfileCommand request)
        {
            request.UserId = User.Identity.Name;
            string uploadName = $"{Guid.NewGuid()}_africuisine_profile_picture_{Path.GetExtension(request.ProfilePicture.FileName)}";
            string path = FileService.GenerateUploadPath(request.MediaType, "Profile", uploadName);
            await FileService.Upload(request.ProfilePicture.OpenReadStream(), path);

            request.Uri = GenerateUri(path, Request);
            ProfileDTO profile = await ProfileService.Add(request);

            return Ok(new Response { Message = "You have successfully added a new profile picture", Succeeded = !string.IsNullOrEmpty(profile.Id) });
        }

        private static string GenerateUri(string path, HttpRequest request)
        {
            var baseUri = $"{request.Scheme}://{request.Host}/api/";
            var relativePath = path.Replace(AppDomain.CurrentDomain.BaseDirectory, "").Replace("\\", "/");
            return $"{baseUri}{relativePath}";
        }

    }
}
