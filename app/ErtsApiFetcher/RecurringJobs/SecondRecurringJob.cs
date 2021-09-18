using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using Hangfire;
using System;

namespace ErtsApiFetcher.RecurringJobs
{
    public class SecondRecurringJob : IRecurringJob
    {
        public string JobName => nameof(SecondRecurringJob);
        public string CronTime => Cron.Minutely();



        public void Job()
        {
            Console.WriteLine("SecondRecurringJob XDDDD " + DateTime.Now.ToString());
            var lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM");

            var champs = lolDataFetcher.FetchMatchesFromTournament(6578);

            Console.WriteLine("test");

            foreach (var champ in champs)
            {
                Console.WriteLine("test2");
                Console.WriteLine(champ.Id);
            }
        }
    }
}
