using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(RarelyChangedDataRecurringJob), nameof(RarelyChangedDataRecurringJob), ErtsCron.Never)]
    public class RarelyChangedDataRecurringJob : IRecurringJob {
        private readonly CsgoDataFetcher csgoDataFetcher;
        private readonly LolDataFetcher lolDataFetcher;
        private readonly ValorantDataFetcher valorantDataFetcher;
        private readonly OwDataFetcher owDataFetcher;
        private readonly Dota2DataFetcher dota2DataFetcher;
        private readonly ErtsContext context;
        public RarelyChangedDataRecurringJob(ErtsContext context) {
            this.context = context;
            var token = "YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM";
            csgoDataFetcher = new CsgoDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
            lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
            valorantDataFetcher = new ValorantDataFetcher(token, context);
            owDataFetcher = new OwDataFetcher(token, context);
            dota2DataFetcher = new Dota2DataFetcher(token, context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();
            FetchAndSaveLolChampions();
            FetchAndSaveLolItems();
            FetchAndSaveLolSpells();

            FetchAndSaveLeagues();
            FetchAndSaveSeries();
            FetchAndSaveTournaments();
            FetchAndSavePlayers();
            FetchAndSaveTeams();

            context.Database.CommitTransaction();
        }

        private void FetchAndSaveTeams() {
            var apiTeams = csgoDataFetcher.FetchTeams();
            apiTeams = apiTeams.Union(lolDataFetcher.FetchTeams());
            apiTeams = apiTeams.Union(valorantDataFetcher.FetchTeams());
            apiTeams = apiTeams.Union(owDataFetcher.FetchTeams());
            apiTeams = apiTeams.Union(dota2DataFetcher.FetchTeams());
            var newTeams = apiTeams.Where(apiTeam => !context.Players.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId));
            context.Teams.AddRange(newTeams);

            context.SaveChanges();
        }

        private void FetchAndSavePlayers() {
            var apiPlayers = csgoDataFetcher.FetchPlayers();
            apiPlayers = apiPlayers.Union(lolDataFetcher.FetchPlayers());
            apiPlayers = apiPlayers.Union(valorantDataFetcher.FetchPlayers());
            apiPlayers = apiPlayers.Union(owDataFetcher.FetchPlayers());
            apiPlayers = apiPlayers.Union(dota2DataFetcher.FetchPlayers());
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);

            context.SaveChanges();
        }

        private void FetchAndSaveTournaments() {
            var apiTournaments = csgoDataFetcher.FetchTournaments();
            apiTournaments = apiTournaments.Union(lolDataFetcher.FetchTournaments());
            apiTournaments = apiTournaments.Union(valorantDataFetcher.FetchTournaments());
            apiTournaments = apiTournaments.Union(owDataFetcher.FetchTournaments());
            apiTournaments = apiTournaments.Union(dota2DataFetcher.FetchTournaments());
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);

            context.SaveChanges();
        }

        private void FetchAndSaveSeries() {
            var apiSeries = csgoDataFetcher.FetchSeries();
            apiSeries = apiSeries.Union(lolDataFetcher.FetchSeries());
            apiSeries = apiSeries.Union(valorantDataFetcher.FetchSeries());
            apiSeries = apiSeries.Union(owDataFetcher.FetchSeries());
            apiSeries = apiSeries.Union(dota2DataFetcher.FetchSeries());
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            context.SaveChanges();
        }

        private void FetchAndSaveLeagues() {
            var apiLeagues = csgoDataFetcher.FetchLeagues();
            apiLeagues = apiLeagues.Union(lolDataFetcher.FetchLeagues());
            apiLeagues = apiLeagues.Union(valorantDataFetcher.FetchLeagues());
            apiLeagues = apiLeagues.Union(owDataFetcher.FetchLeagues());
            apiLeagues = apiLeagues.Union(dota2DataFetcher.FetchLeagues());
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            context.SaveChanges();
        }
        private void FetchAndSaveLolSpells() {
            var apiSpells = lolDataFetcher.FetchSpells();
            var newSpells = apiSpells.Where(apiSpell => !context.LolSpells.Any(contextSpell => contextSpell.Name == apiSpell.Name));
            context.AddRange(newSpells);

            context.SaveChanges();
        }

        private void FetchAndSaveLolItems() {
            var apiItems = lolDataFetcher.FetchItems();
            var newItems = apiItems.Where(apiItem => !context.LolItems.Any(contextItem => contextItem.Name == apiItem.Name));
            context.AddRange(newItems);

            context.SaveChanges();
        }

        private void FetchAndSaveLolChampions() {
            var apiChampions = lolDataFetcher.FetchChampions();
            var newChampions = apiChampions.Where(apiChampion => !context.LolChampions.Any(contextChampion => contextChampion.Name == apiChampion.Name));
            context.AddRange(newChampions);

            context.SaveChanges();
        }
    }
}

