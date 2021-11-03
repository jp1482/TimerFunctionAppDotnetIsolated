using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FunctionApp2
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<IMyRepository, MyRepository>();
                })
                .ConfigureFunctionsWorkerDefaults()
                .Build();

            host.Run();
        }
    }

    public interface IMyRepository
    {
        int GetData();
    }

    public class MyRepository : IMyRepository
    {
        public int GetData()
        {
            return DateTime.Now.Minute;
        }
    }
}