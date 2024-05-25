using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Domain.Entities.User
{
    [Table("Roles")]
    public class Role : IdentityRole<string>, IAuditing
    {
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LUserUpdate { get; set; }
        public int SeqNo { get; set; }
    }
}
