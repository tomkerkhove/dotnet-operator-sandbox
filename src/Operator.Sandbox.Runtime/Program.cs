using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using KubeOps.Operator;

namespace Operator.Sandbox.Runtime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .RunOperator(args); ;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
