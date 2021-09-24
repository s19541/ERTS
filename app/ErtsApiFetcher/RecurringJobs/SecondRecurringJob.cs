using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using System;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs
{
    [RecurringJobInfo(typeof(SecondRecurringJob), nameof(SecondRecurringJob), ErtsCron.Every5Minute)]
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
            var lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);

            var apiLeagues = lolDataFetcher.FetchLeagues();
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            context.SaveChanges();

            var apiSeries = lolDataFetcher.FetchSeries();
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            context.SaveChanges();

            var apiTournaments = lolDataFetcher.FetchTournaments();
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);

            context.SaveChanges();

            var apiPlayers = lolDataFetcher.FetchPlayers();
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);

            //TODO naprawic id teamu w graczach i meczach chyba
            context.SaveChanges();

            var apiTeams = lolDataFetcher.FetchTeams();
            var newTeams = apiTeams.Where(apiTeam => !context.Players.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId));
            context.Teams.AddRange(newTeams);

            context.SaveChanges();

            var apiMatches = lolDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));


            context.Matches.AddRange(newMatches);


            context.SaveChanges();
        }
    }
}
