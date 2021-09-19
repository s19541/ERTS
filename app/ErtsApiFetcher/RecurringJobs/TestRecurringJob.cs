using ErtsApiFetcher._Infrastructure.RecurringJobs;
using System;

namespace ErtsApiFetcher.RecurringJobs
{
    [RecurringJobInfo(typeof(TestRecurringJob), nameof(TestRecurringJob), ErtsCron.Minutely)]
    public class TestRecurringJob : IRecurringJob
    {
        public void Job()
        {
            Console.WriteLine("TestRecuuring joba " + DateTime.Now.ToString());
        }
    }
}
