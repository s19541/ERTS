using ErtsApiFetcher.Services;
using ErtsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErtsApiFetcher.Fetchers {
    public class ValorantDataFetcher : DataFetcherBase {

        public ValorantDataFetcher(string token, ErtsContext context) : base(new DataService(token, "valorant"), context) { }
    }
}
