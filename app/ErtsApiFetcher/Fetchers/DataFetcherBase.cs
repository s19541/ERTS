using ErtsApiFetcher.Services;
using ErtsModel;
using ErtsModel.Enums;
using PandaScoreNET.LoL;
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
        public IEnumerable<ErtsModel.Entities.Team> FetchTeams() {
            var query = new TeamQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetTeams(query));

            var teams = new List<ErtsModel.Entities.Team>();

            foreach (var result in results) {
                var teamPlayers = context.Players.Where(player => result.Players.Select(o => o.Id).Contains(player.ApiId)).ToList();



                teams.Add(new ErtsModel.Entities.Team() {
                    Name = result.Name,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.CurrentVideoGame.Name.ToLower().Replace(":", "")),
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
            var results = provider.FetchAndCatch(lolService => lolService.GetPlayers(query));

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

        public IEnumerable<ErtsModel.Entities.League> FetchLeagues() {
            var query = new LeagueQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetLeagues(query));

            var leagues = new List<ErtsModel.Entities.League>();

            foreach (var result in results) {
                leagues.Add(new ErtsModel.Entities.League() {
                    Name = result.Name,
                    ImageUrl = result.ImageUrl,
                    GameType = (GameType)Enum.Parse(typeof(GameType), result.VideoGame.Name.ToLower().Replace(":", "")),
                    Url = result.Url,
                    ApiId = result.Id
                });
            }

            return leagues;
        }

        public IEnumerable<ErtsModel.Entities.Serie> FetchSeries() {
            var query = new SeriesQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetSeries(query));

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

        public IEnumerable<ErtsModel.Entities.Tournament> FetchTournaments() {
            var query = new TournamentQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetTournaments(query));

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

        public IEnumerable<ErtsModel.Entities.Match> FetchMatches() {
            var query = new MatchQueryOptions();
            var results = provider.FetchAndCatch(lolService => lolService.GetMatches(query));

            var matches = new List<ErtsModel.Entities.Match>();

            foreach (var result in results) {
                var tournament = context.Tournaments.Where(contextTournament => contextTournament.ApiId == result.TournamentId).FirstOrDefault();
                if (result.Opponents.Length == 2) {
                    var team1 = context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[0].Team.Id).FirstOrDefault();
                    var team2 = context.Teams.Where(contextTeam => contextTeam.ApiId == result.Opponents[1].Team.Id).FirstOrDefault();
                    if (team1 != null && team2 != null) {

                        var games = new List<ErtsModel.Entities.Game>();

                        foreach (var newGame in result.Games) {
                            if (newGame.BeginAt != null && newGame.EndAt != null)
                                games.Add(new ErtsModel.Entities.Game() {
                                    StartTime = (DateTime)newGame.BeginAt,
                                    EndTime = (DateTime)newGame.EndAt,
                                    Winner = context.Teams.Where(contextTeam => contextTeam.ApiId == newGame.Winner.ID).FirstOrDefault(),
                                    ApiId = newGame.Id,
                                });
                            var newGames = games.Where(apiGame => !context.Games.Any(contextGame => contextGame.ApiId == apiGame.ApiId));
                            context.Games.AddRange(newGames);
                        }
                        matches.Add(new ErtsModel.Entities.Match() {
                            ApiId = result.Id,
                            StreamUrl = result.LiveUrl,
                            StartTime = result.BeginAt,
                            EndTime = result.EndAt,
                            Tournament = tournament,
                            Team1 = team1,
                            Team2 = team2,
                            Games = games

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
