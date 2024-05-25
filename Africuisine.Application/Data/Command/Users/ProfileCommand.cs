using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Africuisine.Application.Data.Command.Users
{
    public class ProfileCommand
    {
        public string Id { get; set; }
        public string Bio { get; set; }
        public string MediaType { get; set; }
        public IFormFile ProfilePicture { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        [JsonIgnore]
        public string Uri { get; set; }
    }
}
