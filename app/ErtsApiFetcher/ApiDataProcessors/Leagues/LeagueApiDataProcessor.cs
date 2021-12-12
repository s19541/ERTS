using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Leagues {
    public class LeagueApiDataProcessor : ApiDataProcessor<LeagueApiDataProcessorParameter> {
        public LeagueApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(LeagueApiDataProcessorParameter parameter) {
            var apiLeagues = parameter.DataFetcher.FetchLeagues(parameter.FromTime);
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            var updatedLeagues = apiLeagues.Where(apiLeague => context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            foreach (var updatedLeague in updatedLeagues) {
                var contextLeague = context.Leagues.Where(contextLeague => contextLeague.ApiId == updatedLeague.ApiId).FirstOrDefault();
                contextLeague.Update(updatedLeague.Name, updatedLeague.ImageUrl, updatedLeague.GameType, updatedLeague.Url);
            }
        }
    }
}
