using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Domain.Entities
{
    public interface IDataEntity : IAuditing
    {
        public string Id { get; set; }
    }
}
