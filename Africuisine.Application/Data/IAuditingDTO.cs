using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data
{
    public interface IAuditingDTO
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int SeqNo { get; set; }
        public string LUserUpdate { get; set; }
    }
}
