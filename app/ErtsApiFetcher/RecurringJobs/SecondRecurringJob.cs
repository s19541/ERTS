using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using System;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs
{
    [RecurringJobInfo(typeof(SecondRecurringJob), nameof(SecondRecurringJob), ErtsCron.Minutely)]
    public class SecondRecurringJob : IRecurringJob
    {
        private readonly ErtsContext context;
        public SecondRecurringJob(ErtsContext context)
        {
            this.context = context;
        }

        public void Job()
        {
            Console.WriteLine("SecondRecurringJob XDDDD " + DateTime.Now.ToString());
            var lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM");

            var leagues = lolDataFetcher.FetchLeagues();
            Console.WriteLine(context.Leagues.First().Name);

            var ApiIds = context.Leagues.Select(o => o.ApiId).ToList();

            foreach (var league in leagues)
            {
                if (!ApiIds.Contains(league.ApiId))
                    context.Leagues.Add(league);
                Console.WriteLine(league.ApiId);
            }
            context.SaveChanges();
        }
    }
}
