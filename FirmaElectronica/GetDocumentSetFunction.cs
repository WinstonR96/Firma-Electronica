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
using FirmaElectronicaOnBase;

namespace FirmaElectronica
{
    public static class GetDocumentSetFunction
    {
        [FunctionName("GetDocumentSetFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                RootGetDocumentSet data = JsonConvert.DeserializeObject<RootGetDocumentSet>(requestBody);
                if(data != null)
                {
                    string token = data.AuthToken.Token;
                    int docSetId = int.Parse(data.GetDocumentSet.DocumentSetId);
                    bool sendDocument = data.GetDocumentSet.SendDocument;
                    RespuestaGetDocumentSet respuestaGetDocumentSet = FirmaElectronicaOnBase.FirmaElectronica.GetDocumentSet(token, docSetId, sendDocument);
                    return new OkObjectResult(respuestaGetDocumentSet);
                }
                else
                {
                    return new BadRequestObjectResult("Por favor ingrese información en el body");
                }
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
