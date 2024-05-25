using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Config;
using Africuisine.Application.Data.Res;
using Microsoft.Extensions.Options;
using PostmarkDotNet;

namespace Africuisine.Infrastructure.Email
{
    public class PostmarkService : IPostmarkService
    {
        private static PostmarkConfig Postmark { get; set; }
        private PostmarkClient Client { get; set; }

        public PostmarkService(IOptions<PostmarkConfig> options)
        {
            Postmark = options.Value;
            Client = new(Postmark.Key);
        }
        public async Task<Response> SendEmailWithTemplate(UserCommand user, string url)
        {
            var message = GetTemplatedPostmarkMessage(user, url);
            var BaseResponse = await Client.SendEmailWithTemplateAsync(message);
            bool succeeded = BaseResponse.Status == PostmarkStatus.Success;
            return new Response { Message = BaseResponse.Message, Succeeded = succeeded };
        }
        private static Dictionary<string, object> GetTemplateModel(PostmarkConfig sender, string name, string url)
        {
            return new Dictionary<string, object> {
                { "product_url", sender.CompanyUrl },
                { "product_name", sender.CompanyName},
                { "name", name },
                { "action_url", url },
                { "sender_name", sender.SenderName },
                { "support_email", sender.SupportEmail },
                { "company_name", sender.CompanyName },
                { "company_address", "company_address_Value" },
            };
        }
         private static TemplatedPostmarkMessage GetTemplatedPostmarkMessage(UserCommand recipient, string url)
        {
            var template = GetTemplateModel(Postmark, recipient.FullName, url);
            return new TemplatedPostmarkMessage
            {
                From = Postmark.SenderEmail,
                TemplateAlias = "confirmation",
                To = recipient.UserName,
                TemplateModel = template
            };
        
}

    }
}
