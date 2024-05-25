using System.Text.Json;

namespace Africuisine.Application.Data.Config
{
    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}