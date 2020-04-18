using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FirmaElectronica.Models;
using System;

namespace FirmaElectronica
{
    public static class NewDocumentSetFunction
    {
        [FunctionName("NewDocumentSetFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                RootObject data = JsonConvert.DeserializeObject<RootObject>(requestBody);
                if (data != null)
                {
                    return new JsonResult(data);
                }
                else
                {
                    return new BadRequestObjectResult("Please pass a data in the request body");
                }
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

        }
    }
}
