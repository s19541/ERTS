using ErtsApiFetcher.Services;
using ErtsModel;

namespace ErtsApiFetcher.Fetchers {
    public class Dota2DataFetcher : DataFetcherBase {

        public Dota2DataFetcher(string token, ErtsContext context) : base(new DataService(token, "dota2"), context) { }
    }
}