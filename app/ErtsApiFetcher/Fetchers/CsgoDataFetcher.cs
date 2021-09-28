using ErtsApiFetcher.Services;
using ErtsModel;

namespace ErtsApiFetcher.Fetchers {
    public class CsgoDataFetcher : DataFetcherBase {

        public CsgoDataFetcher(string token, ErtsContext context) : base(new DataService(token, "csgo"), context) { }
    }
}
