using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data.Res
{
    internal class ItemResponse<T> : Response where T : class
    {
        public T Item { get; set; }
    }
}
