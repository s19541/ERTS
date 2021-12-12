using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolChampions {
    public class LolChampionApiDataProcessor : ApiDataProcessor<LolChampionApiDataProcessorParameter> {
        public LolChampionApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(LolChampionApiDataProcessorParameter parameter) {
            var apiChampions = parameter.DataFetcher.FetchChampions();
            var newChampions = apiChampions.Where(apiChampion => !context.LolChampions.Any(contextChampion => contextChampion.Name == apiChampion.Name));
            context.AddRange(newChampions);
        }
    }
}
