using Microsoft.AspNetCore.Http;

namespace Application.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static void AddApplicationExtension(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Exception", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Exception");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddArgumentsExtension(this HttpResponse response, string message)
        {
            response.Headers.Add("Argument-Exception", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Argument-Exception");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddNotFoundExtension(this HttpResponse response, string message)
        {
            response.Headers.Add("Not-Found-Exception", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Not-Found-Exception");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddValidationExtension(this HttpResponse response, string message)
        {
            response.Headers.Add("Validation-Exception", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Validation-Exception");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}