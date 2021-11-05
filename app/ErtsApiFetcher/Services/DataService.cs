using PandaScoreNET;
using System;
using System.Net.Http;

namespace ErtsApiFetcher.Services {
    public class DataService {
        private readonly PandaScoreProvider provider;

        public DataService(string token, string game) {
            provider = new PandaScoreProvider(token, game);
        }

        public T FetchAndCatch<T>(Func<PandaScoreProvider, T> fetch) {
            try {
                return fetch(provider);
            } catch (HttpRequestException) {
                throw;
            } catch (AggregateException e) {
                System.Console.WriteLine(e.ToString());
                throw new NoAmmoException();
            } catch (Exception) {
                throw;
            }
        }
    }
}
