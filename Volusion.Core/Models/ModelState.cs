using System.Net;

namespace Volusion.Core.Models
{
    public class ModelState
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string UserMessage { get; set; }
        public string LogMessage { get; set; }
    }
}