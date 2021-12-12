using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Players {
    public class PlayerApiDataProcessor : ApiDataProcessor<PlayerApiDataProcessorParameter> {
        public PlayerApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(PlayerApiDataProcessorParameter parameter) {
            var apiPlayers = parameter.DataFetcher.FetchPlayers();
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);
        }
    }
}
