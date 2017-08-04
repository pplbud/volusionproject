using Newtonsoft.Json;

namespace Volusion.Core.Api.Responses
{
    public class StandardResponse
    {
        public StandardResponse()
        {
            Status = new StatusJson();
        }

        [JsonProperty(PropertyName = "status")]
        public StatusJson Status { get; set; }

        public class StatusJson
        {
            [JsonProperty(PropertyName = "code")]
            public int Code { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "userMessage")]
            public string UserMessage { get; set; }

            [JsonProperty(PropertyName = "logMessage")]
            public string LogMessage { get; set; }
        }
    }
}