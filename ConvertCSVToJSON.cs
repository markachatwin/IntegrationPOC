using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Aruma.Integration
{
    public class ConvertCSVToJSON
    {
        private readonly ILogger<ConvertCSVToJSON> _logger;

        public ConvertCSVToJSON(ILogger<ConvertCSVToJSON> logger)
        {
            _logger = logger;
        }

        [Function("ConvertCSVToJSON")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            
            string data = req.Query["data"];
            string fileType = req.Query["fileType"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"Request Body Size: {requestBody.Length}");
            //dynamic request = JsonConvert.DeserializeObject(requestBody);
            //data = data ?? request?.data;
            //fileType = fileType ?? request?.fileType;
            string result = $"Testing: {requestBody.Length}";

            //byte[] byteArray = Encoding.UTF8.GetBytes(data);

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Content-Type", "text/plain");  
            response.WriteString(result);

            return response;
        }        
    }
}
