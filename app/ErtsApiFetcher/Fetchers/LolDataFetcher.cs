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
        public LolDataFetcher(string token, ErtsContext context)
        {
            Provider = new PandaScoreLoLProvider(token);
            Context = context;
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
                var players = Context.Players.Where(player => result.Players.Select(o => o.Id).Contains(player.ApiId)).ToList();

                teams.Add(new ErtsModel.Entities.Team()
                {
                    Name = result.Name,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.CurrentVideoGame.Name),
                    ImageUrl = result.ImageUrl,
                    Acronym = result.Acronym,
                    Players = players,
                    ApiId = result.Id
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
                    Nationality = result.Nationality,
                    ApiId = result.Id
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
                var league = Context.Leagues.Where(league => league.ApiId == result.LeagueId).FirstOrDefault();
                if (league != null)
                    series.Add(new ErtsModel.Entities.Serie()
                    {
                        ApiId = result.Id,
                        Name = result.Name != null ? result.Name : "",
                        StartTime = result.BeginAt,
                        EndTime = result.EndAt,
                        League = league
                    });
            }

            return series;
        }

        public IEnumerable<ErtsModel.Entities.Tournament> FetchTournaments()
        {
            var query = new TournamentQueryOptions();
            var results = Provider.GetTournaments(query);

            var tournaments = new List<ErtsModel.Entities.Tournament>();

            foreach (var result in results)
            {
                var serie = Context.Series.Where(serie => serie.ApiId == result.SeriesId).FirstOrDefault();
                if (serie != null)
                    tournaments.Add(new ErtsModel.Entities.Tournament()
                    {
                        ApiId = result.Id,
                        Name = result.Name != null ? result.Name : "",
                        StartTime = result.BeginAt,
                        EndTime = result.EndAt,
                        Serie = serie
                    });
            }

            return tournaments;
        }

        public IEnumerable<ErtsModel.Entities.Match> FetchMatches()
        {
            var query = new MatchQueryOptions();
            var results = Provider.GetMatches(query);

            var matches = new List<ErtsModel.Entities.Match>();

            foreach (var result in results)
            {
                var tournament = Context.Tournaments.Where(contextTournament => contextTournament.ApiId == result.TournamentId).FirstOrDefault();
                if (result.Opponents.Length == 2)
                {
                    var team1 = Context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[0].Team.Id).FirstOrDefault();
                    var team2 = Context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[1].Team.Id).FirstOrDefault();

                    //TODO naprawic by dobrze dodwalo id teamkow
                    matches.Add(new ErtsModel.Entities.Match()
                    {
                        ApiId = result.Id,
                        StreamUrl = result.LiveUrl,
                        StartTime = result.BeginAt,
                        EndTime = result.EndAt,
                        Tournament = tournament,
                        Team1 = team1,
                        Team2 = team2

                    });
                }

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
