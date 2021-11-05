using ErtsApiFetcher.Services;
using ErtsModel;

namespace ErtsApiFetcher.Fetchers {
    public class OwDataFetcher : DataFetcherBase {

        public OwDataFetcher(string token, ErtsContext context) : base(new DataService(token, "ow"), context) { }
    }
}
