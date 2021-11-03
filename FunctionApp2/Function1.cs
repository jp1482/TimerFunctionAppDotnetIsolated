using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp2
{
    public class FunctionApp
    {
        private readonly IMyRepository _myRepository;

        public FunctionApp(IMyRepository myRepository)
        {
            _myRepository = myRepository;
        }

        [Function("MyAzureFunction")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, FunctionContext context)
        {
            ILogger logger = context.GetLogger("MyAzureFunction");
            logger.LogInformation($"C# Timer trigger function executed at: {_myRepository.GetData()}");

        }
    }
}
