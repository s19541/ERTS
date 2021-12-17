using ErtsApiFetcher.Services;
using ErtsModel;
using ErtsModel.Enums;
using PandaScore.NET.Entities.QueryOptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.Fetchers {
    public abstract class DataFetcherBase {
        protected readonly DataService provider;
        protected readonly ErtsContext context;
        protected DataFetcherBase(DataService provider, ErtsContext context) {
            this.provider = provider;
            this.context = context;
        }
        public IEnumerable<ErtsModel.Entities.Team> FetchTeams(DateTime? from = null) {
            var query = new TeamQueryOptions();
            if (from != null)
                query.ModifiedAt.Range(from.Value, DateTime.Now);
            var results = provider.FetchAndCatch(service => service.GetTeams(query));

            var teams = new List<ErtsModel.Entities.Team>();

            foreach (var result in results) {

                foreach (var player in result.Players.Where(player => !context.Players.Select(o => o.ApiId).Contains(player.Id)).ToList()) {
                    context.Add(new ErtsModel.Entities.Player() {
                        Nick = player.Name,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Nationality = player.Nationality,
                        ApiId = player.Id
                    });
                    context.SaveChanges();
                }

                var teamPlayers = context.Players.Where(player => result.Players.Select(o => o.Id).Contains(player.ApiId)).ToList();



                teams.Add(new ErtsModel.Entities.Team() {
                    Name = result.Name,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.CurrentVideoGame.Name.ToLower().Replace(":", "").Replace(" ", "")),
                    ImageUrl = result.ImageUrl,
                    Acronym = result.Acronym,
                    Players = teamPlayers,
                    ApiId = result.Id
                });
            }

            return teams;
        }

        public IEnumerable<ErtsModel.Entities.Player> FetchPlayers() {
            var query = new PlayerQueryOptions();
            var results = provider.FetchAndCatch(service => service.GetPlayers(query));

            var players = new List<ErtsModel.Entities.Player>();

            foreach (var result in results) {
                if (result.CurrentTeam != null)
                    players.Add(new ErtsModel.Entities.Player() {
                        Nick = result.Name,
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        Nationality = result.Nationality,
                        ApiId = result.Id
                    });
            }

            return players;
        }

        public IEnumerable<ErtsModel.Entities.League> FetchLeagues(DateTime? from = null) {
            var query = new LeagueQueryOptions();
            if (from != null)
                query.ModifiedAt.Range(from.Value, DateTime.Now);
            var results = provider.FetchAndCatch(service => service.GetLeagues(query));

            var leagues = new List<ErtsModel.Entities.League>();

            foreach (var result in results) {
                leagues.Add(new ErtsModel.Entities.League() {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.VideoGame.Name.ToLower().Replace(":", "").Replace(" ", "")),
                    Url = result.Url,
                    ApiId = result.Id
                });
            }

            return leagues;
        }

        public IEnumerable<ErtsModel.Entities.Serie> FetchSeries(DateTime? from = null) {
            var query = new SeriesQueryOptions();
            if (from != null)
                query.ModifiedAt.Range(from.Value, DateTime.Now);
            var results = provider.FetchAndCatch(service => service.GetSeries(query));

            var series = new List<ErtsModel.Entities.Serie>();

            foreach (var result in results) {

                var league = context.Leagues.Where(league => league.ApiId == result.LeagueId).FirstOrDefault();

                if (league != null) {
                    var name = result.Name != null && result.Name != "" ? result.Name : league.Name + " " + result.BeginAt?.Year;
                    var sameNameSerie = series.Where(serie => serie.Name == name).FirstOrDefault();
                    if (sameNameSerie != null) {
                        if (result.EndAt != null) {
                            name += " " + getSeason(result.EndAt.Value).ToString();
                        } else if (result.BeginAt != null) {
                            name += " " + getSeason(result.BeginAt.Value).ToString();
                        }
                        if (sameNameSerie.EndTime != null) {
                            sameNameSerie.Name += " " + getSeason(sameNameSerie.EndTime.Value).ToString();
                        } else if (sameNameSerie.StartTime != null) {
                            sameNameSerie.Name += " " + getSeason(sameNameSerie.StartTime.Value).ToString();
                        }
                    }

                    series.Add(new ErtsModel.Entities.Serie() {
                        ApiId = result.Id,
                        Name = name,
                        StartTime = result.BeginAt,
                        EndTime = result.EndAt,
                        League = league
                    });
                }

            }

            return series;
        }

        public IEnumerable<ErtsModel.Entities.Tournament> FetchTournaments(DateTime? from = null) {
            var query = new TournamentQueryOptions();
            if (from != null)
                query.ModifiedAt.Range(from.Value, DateTime.Now);
            var results = provider.FetchAndCatch(service => service.GetTournaments(query));

            var tournaments = new List<ErtsModel.Entities.Tournament>();

            foreach (var result in results) {
                var serie = context.Series.Where(serie => serie.ApiId == result.SeriesId).FirstOrDefault();
                if (serie != null)
                    tournaments.Add(new ErtsModel.Entities.Tournament() {
                        ApiId = result.Id,
                        Name = result.Name != null ? result.Name : "",
                        StartTime = result.BeginAt,
                        EndTime = result.EndAt,
                        Serie = serie
                    });
            }

            return tournaments;
        }

        public IEnumerable<ErtsModel.Entities.Match> FetchMatches(DateTime? from = null) {
            var query = new MatchQueryOptions();
            if (from != null)
                query.ModifiedAt.Range(from.Value, DateTime.Now);
            var results = provider.FetchAndCatch(service => service.GetMatches(query));

            var matches = new List<ErtsModel.Entities.Match>();

            foreach (var result in results) {
                var tournament = context.Tournaments.Where(contextTournament => contextTournament.ApiId == result.TournamentId).FirstOrDefault();

                if (result.Opponents.Length == 2) {
                    var team1 = context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[0].Team.Id).FirstOrDefault();
                    var team2 = context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[1].Team.Id).FirstOrDefault();
                    if (team1 != null && team2 != null) {

                        var games = new List<ErtsModel.Entities.Game>();

                        foreach (var newGame in result.Games) {
                            if (newGame.BeginAt != null && newGame.EndAt != null && !context.Games.Any(contextGame => contextGame.ApiId == newGame.Id)) {
                                games.Add(new ErtsModel.Entities.Game() {
                                    StartTime = (DateTime)newGame.BeginAt,
                                    EndTime = (DateTime)newGame.EndAt,
                                    Winner = context.Teams.Where(contextTeam => contextTeam.ApiId == newGame.Winner.ID).FirstOrDefault(),
                                    ApiId = newGame.Id,
                                });
                            }
                        }
                        matches.Add(new ErtsModel.Entities.Match() {
                            ApiId = result.Id,
                            StreamUrl = result.LiveUrl,
                            StartTime = result.BeginAt,
                            EndTime = result.EndAt,
                            Tournament = tournament,
                            Team1 = team1,
                            Team2 = team2,
                            Games = games,
                            NumberOfGames = result.NumberOfGames

                        });

                    }
                }
            }

            return matches;
        }

        private Season getSeason(DateTime date) {

            int doy = date.DayOfYear - Convert.ToInt32((DateTime.IsLeapYear(date.Year)) && date.DayOfYear > 59);

            if (doy < 80 || doy >= 355) return Season.Winter;

            if (doy >= 80 && doy < 172) return Season.Spring;

            if (doy >= 172 && doy < 266) return Season.Summer;

            return Season.Autumn;
        }
    }
}
