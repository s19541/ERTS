using ErtsApiFetcher._Infrastructure.RecurringJobs;
using Hangfire;
using System;

namespace ErtsApiFetcher.RecurringJobs
{
    public class TestRecurringJob : IRecurringJob
    {
        public string JobName => nameof(TestRecurringJob);
        public string CronTime => Cron.Minutely();

        public void Job()
        {
            Console.WriteLine("TestRecuuring joba " + DateTime.Now.ToString());
        }
    }
}
