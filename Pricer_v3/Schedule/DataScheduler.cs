using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;

namespace Pricer_v3.Schedule
{
    public class DataScheduler
    {
               
        public static async void Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
            await scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<DataJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("DailyTrigger", "default")
                .StartAt(new DateTimeOffset(DateTime.Today.AddHours(5)))
                .WithSimpleSchedule(x => x
                    //   .WithIntervalInMinutes(5)
                    .WithIntervalInHours(24)
                    .RepeatForever())
                    .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}