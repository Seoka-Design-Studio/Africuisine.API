using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Data.Res
{
    public class ItemsResponse<T> : Response where T : class
    {
       public List<T> Items {get; set;}
    }
}
