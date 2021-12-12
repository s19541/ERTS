using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Series {
    public class SerieApiDataProcessor : ApiDataProcessor<SerieApiDataProcessorParameter> {
        public SerieApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(SerieApiDataProcessorParameter parameter) {
            var apiSeries = parameter.DataFetcher.FetchSeries(parameter.FromTime);
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);
        }
    }
}
