using System.Net;
using System.Text.Json.Serialization;

namespace _4Tables2._0.Domain.Base.Common
{
    public class Error
    {
        [JsonIgnore]
        public int StatusCode {  get; set; }
        public string Message { get; set; }

        public Error(HttpStatusCode httpStatusCode, string message)
        {
            StatusCode = (int)httpStatusCode;
            Message = message;
        }

        public static readonly Error None = new(HttpStatusCode.Continue, string.Empty);
    }
}
