using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using System;
using System.Collections.Generic;
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

            var apiLeagues = lolDataFetcher.FetchLeagues();
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));

            context.Leagues.AddRange(newLeagues);

            var newSeries = new List<ErtsModel.Entities.Serie>();
            foreach (var apiLeague in apiLeagues)
            {
                var apiSeries = lolDataFetcher.FetchSeriesFromLeague(apiLeague);
                newSeries.AddRange(apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId)));
            }
            context.Series.AddRange(newSeries);

            context.SaveChanges();
        }
    }
}
