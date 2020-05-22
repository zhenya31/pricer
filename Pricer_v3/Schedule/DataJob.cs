using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Pricer_v3.Schedule
{
    public class DataJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        
        async public Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                Console.WriteLine("Monitoring started...");
                try
                {
                    var dailyService = scope.ServiceProvider.GetService<IDailyService>();
                    await dailyService.CheckPrices();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}