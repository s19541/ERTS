using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Series {
    public class SerieApiDataProcessor : ApiDataProcessor<SerieApiDataProcessorParameter> {
        public SerieApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(SerieApiDataProcessorParameter parameter) {
            var apiSeries = parameter.DataFetcher.FetchSeries(parameter.FromTime);
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            var updatedSeries = apiSeries.Where(apiSerie => context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            foreach (var updatedSerie in updatedSeries) {
                var contextSerie = context.Series.Where(contextSerie => contextSerie.ApiId == updatedSerie.ApiId).FirstOrDefault();
                contextSerie.Update(updatedSerie.Name, updatedSerie.StartTime, updatedSerie.EndTime, updatedSerie.League);
            }
        }
    }
}
