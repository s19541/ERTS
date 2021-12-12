using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolItems {
    public class LolItemApiDataProcessor : ApiDataProcessor<LolItemApiDataProcessorParameter> {
        public LolItemApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(LolItemApiDataProcessorParameter parameter) {
            var apiItems = parameter.DataFetcher.FetchItems();
            var newItems = apiItems.Where(apiItem => !context.LolItems.Any(contextItem => contextItem.Name == apiItem.Name));
            context.AddRange(newItems);
        }
    }
}
