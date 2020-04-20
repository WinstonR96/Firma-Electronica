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
using FirmaElectronica.Utils;
using FirmaElectronica.Models.Response;

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
                RootNewDocumentSet data = JsonConvert.DeserializeObject<RootNewDocumentSet>(requestBody);
                if (data != null)
                {

                    ObjectDll objectDll = Helper.CastData(data);
                    string mensaje = "";
                    string docSetId = "1";
                    Response response = new Response();
                    //bool res = true;
                    bool res = FirmaElectronicaOnBase.FirmaElectronica.NewDocumentSet(objectDll.senderEmail, objectDll.authToken, objectDll.docSetName, objectDll.daysRemainder, objectDll.daysExpiration, objectDll.pdfFileName, objectDll.pdfB64, objectDll.destinatarios, out mensaje, out docSetId);
                    if (res)
                    {
                        response.exitoso = res;
                        response.docSetId = docSetId;
                        response.mensaje = "Se envió el documento a firmar";
                        return (ActionResult)new OkObjectResult(response);
                    }
                    else
                    {
                        response.exitoso = res;
                        response.docSetId = docSetId;
                        response.mensaje = "No se envió el documento a firmar";
                        return (ActionResult)new OkObjectResult(response);
                    }
                }
                else
                {
                    return new BadRequestObjectResult("Por favor ingrese información en el body");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}
