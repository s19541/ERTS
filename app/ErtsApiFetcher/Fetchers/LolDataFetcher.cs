using ErtsModel;
using ErtsModel.Entities.Lol;
using ErtsModel.Enums;
using PandaScoreNET;
using PandaScoreNET.LoL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.Fetchers
{
    class LolDataFetcher
    {
        private readonly PandaScoreLoLProvider Provider;
        private readonly ErtsContext Context;
        public LolDataFetcher(string token)
        {
            Provider = new PandaScoreLoLProvider(token);
        }

        public IEnumerable<LolChampion> FetchChampions()
        {
            var query = new ChampionQueryOptions();
            query.Name.Sort();
            var results = Provider.GetChampions(query);

            var lolChampions = new List<LolChampion>();

            foreach (var result in results)
            {
                lolChampions.Add(new LolChampion()
                {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl
                });
            }

            return lolChampions;
        }

        public IEnumerable<ErtsModel.Entities.Team> FetchTeams()
        {
            var query = new TeamQueryOptions();
            var results = Provider.GetTeams(query);

            var teams = new List<ErtsModel.Entities.Team>();

            foreach (var result in results)
            {
                var players = new List<ErtsModel.Entities.Player>();
                result.Players.ToList().ForEach(o => players.Add(new ErtsModel.Entities.Player()
                {
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Nick = o.Name,
                    Nationality = o.Nationality
                }));
                teams.Add(new ErtsModel.Entities.Team()
                {
                    Name = result.Name,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.CurrentVideoGame.Name),
                    ImageUrl = result.ImageUrl,
                    Acronym = result.Acronym,
                    Players = players
                });
            }

            return teams;
        }

        public IEnumerable<ErtsModel.Entities.Player> FetchPlayers()
        {
            var query = new PlayerQueryOptions();
            var results = Provider.GetPlayers(query);

            var players = new List<ErtsModel.Entities.Player>();

            foreach (var result in results)
            {
                players.Add(new ErtsModel.Entities.Player()
                {
                    Nick = result.Name,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Nationality = result.Nationality
                });
            }

            return players;
        }

        public IEnumerable<ErtsModel.Entities.League> FetchLeagues()
        {
            var query = new LeagueQueryOptions();
            var results = Provider.GetLeagues(query);

            var leagues = new List<ErtsModel.Entities.League>();

            foreach (var result in results)
            {
                leagues.Add(new ErtsModel.Entities.League()
                {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.VideoGame.Name),
                    Url = result.Url,
                    ApiId = result.Id
                });
            }

            return leagues;
        }

        public IEnumerable<ErtsModel.Entities.Serie> FetchSeries()
        {
            var query = new SeriesQueryOptions();
            var results = Provider.GetSeries(query);

            var series = new List<ErtsModel.Entities.Serie>();

            foreach (var result in results)
            {
                series.Add(new ErtsModel.Entities.Serie()
                {
                    Id = result.Id,
                    Name = result.Name,
                    StartTime = result.BeginAt,
                    EndTime = result.EndAt,
                    League = new ErtsModel.Entities.League() { }
                });
            }

            return series;
        }

        public IEnumerable<ErtsModel.Entities.Match> FetchMatches()
        {
            var query = new MatchQueryOptions();
            var results = Provider.GetMatches(query);

            var matches = new List<ErtsModel.Entities.Match>();

            foreach (var result in results)
            {
                matches.Add(new ErtsModel.Entities.Match()
                {
                    Id = result.Id,
                    StreamUrl = result.LiveUrl
                });
            }

            return matches;
        }

        public IEnumerable<ErtsModel.Entities.Match> FetchMatchesFromTournament(int tournamentId)
        {
            var query = new MatchQueryOptions();
            query.TournamentId.Filter(tournamentId);
            var results = Provider.GetMatches(query);

            var matches = new List<ErtsModel.Entities.Match>();

            foreach (var result in results)
            {
                matches.Add(new ErtsModel.Entities.Match()
                {
                    Id = result.Id,
                    StreamUrl = result.LiveUrl
                });
            }

            return matches;
        }

    }
}
