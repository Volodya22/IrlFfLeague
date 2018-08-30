using System.Collections.Specialized;
using System.IO;
using IrlFfLeague.Web.Jobs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Quartz;
using Quartz.Impl;

namespace IrlFfLeague.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            StartScheduler();

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static async void StartScheduler()
        {
            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            var factory = new StdSchedulerFactory(props);

            var sched = await factory.GetScheduler();
            await sched.Start();

            var job = JobBuilder.Create<UpdateDataJob>()
                .WithIdentity("updateJob", "updateJobGroup")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("updateTrigger", "updateTriggerGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(12)
                    .RepeatForever())
                .Build();

            //await sched.ScheduleJob(job, trigger);
        }
    }
}
