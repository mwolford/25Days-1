using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace mwolford.serverless
{
    public static class SpinDreidel
    {
        private static string[] responses = {"Nun","Gimmel", "Hay","Shin"};

        [FunctionName("SpinDreidel")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var randomizer = new Random();
            var index = randomizer.Next(SpinDreidel.responses.Length);
            var response = SpinDreidel.responses[index];
            log.LogInformation($"Index: [{index}], Response Value: [{response}]");

            return (ActionResult)new OkObjectResult(response);
        }
    }
}
