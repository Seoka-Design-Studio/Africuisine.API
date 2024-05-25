using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data.Config
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string ValidIssuer { get; set; }
        public List<string> ValidAudiences { get; set; }
    }
}
