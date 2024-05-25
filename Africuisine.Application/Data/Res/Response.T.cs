using Africuisine.Application.Data.Res;

namespace Africuisine.Application;

public class Response<TType> : Response
{
    public TType Data { get; set; }
}
