using System.Web;
using Africuisine.Application.Config;
using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Contracts;
using Africuisine.Infrastructure.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.Application.Controllers.Users
{
    public class UsersController : APIBaseController
    {
        private readonly IUserService UserService;
        private readonly IPostmarkService PostmarkService;

        public UsersController(IUserService userService, IPostmarkService postmarkService)
        {
            UserService = userService;
            PostmarkService = postmarkService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult>Add(UserCommand request)
        {
            var user = await UserService.SignUpWithEmailAndPassword(request);
            string token = await UserService.GenerateEmailConfirmationToken(user);
            string uri = string.Format("{0}://{1}/api/users/account-verification?token={2}&id={3}", Request.Scheme, Request.Host,
            HttpUtility.UrlEncode(token), user.Id);
            var response = await PostmarkService.SendEmailWithTemplate(request, uri);
            return Ok(response);
        }
        [HttpGet("account-verification")]
        [AllowAnonymous]
        public async Task<IActionResult> AccountVerification([FromQuery]string token, [FromQuery]string id)
        {
            var response = await UserService.AccountVerification(token, id);
            return Ok(new Response { Message = "You have successfully verified your account.", Succeeded = response.Succeeded });
        }

    }
}
