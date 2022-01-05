using ErtsApplication.DTO;
using ErtsModel;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL {
    public class TeamDbService : ITeamDbService {
        public ErtsContext Context { get; set; }
        public TeamDbService(ErtsContext dbContext) {
            Context = dbContext;
        }
        public ActionResult<TeamDto> GetTeam(int teamId) {
            var team = Context.Teams.Where(contextTeam => contextTeam.Id == teamId).FirstOrDefault();

            var lastMatches = Context.Matches.Where(contextMatch => (contextMatch.Team1.Id == teamId || contextMatch.Team2.Id == teamId) && contextMatch.EndTime != null).OrderByDescending(contextMatch => contextMatch.StartTime).ToList().Take(5);
            var lastMatchesDto = new List<TeamPastMatchDto>();


            foreach (var match in lastMatches) {
                var team1GamesWon = 0;
                var team2GamesWon = 0;

                foreach (var game in match.Games) {
                    if (game.Winner == match.Team1)
                        team1GamesWon++;
                    else
                        team2GamesWon++;
                }
                lastMatchesDto.Add(new TeamPastMatchDto() {
                    MatchId = match.Id,
                    StartTime = match.StartTime,
                    Team1Name = match.Team1.Name,
                    Team2Name = match.Team2.Name,
                    Team1ImageUrl = match.Team1.ImageUrl,
                    Team2ImageUrl = match.Team2.ImageUrl,
                    LeagueImageUrl = match.Tournament.Serie.League.ImageUrl,
                    Team1GamesWon = team1GamesWon,
                    Team2GamesWon = team2GamesWon
                });
            }
            var upcomingMatches = Context.Matches.Where(contextMatch => (contextMatch.Team1.Id == teamId || contextMatch.Team2.Id == teamId) && contextMatch.StartTime > System.DateTime.Now).OrderBy(contextMatch => contextMatch.StartTime).ToList().Take(5);
            var upcomingMatchesDto = new List<TeamUpcomingMatchDto>();
            foreach (var match in upcomingMatches) {
                upcomingMatchesDto.Add(new TeamUpcomingMatchDto() {
                    MatchId = match.Id,
                    StartTime = match.StartTime,
                    Team1Name = match.Team1.Name,
                    Team2Name = match.Team2.Name,
                    Team1ImageUrl = match.Team1.ImageUrl,
                    Team2ImageUrl = match.Team2.ImageUrl,
                    LeagueImageUrl = match.Tournament.Serie.League.ImageUrl
                });
            }
            return new TeamDto() {
                Name = team.Name,
                ImageUrl = team.ImageUrl,
                Acronym = team.Acronym,
                GameType = team.GameType,
                Players = team.Players,
                LastMatches = lastMatchesDto,
                UpcomingMatches = upcomingMatchesDto
            };
        }

        public ActionResult<IEnumerable<TeamImageDto>> GetTeamImages(GameType gameType, string fragment) {
            List<TeamImageDto> teamImageDtos = new List<TeamImageDto>();
            System.Console.WriteLine("testetateat");
            var teams = Context.Teams.Where(contextTeam => contextTeam.GameType == gameType && (fragment == null || contextTeam.Name.ToLower().Contains(fragment))).ToList();

            foreach (var team in teams) {
                var teamImageDto = new TeamImageDto() {
                    Id = team.Id,
                    ImageUrl = team.ImageUrl,
                    Name = team.Name
                };

                teamImageDtos.Add(teamImageDto);
            }
            return teamImageDtos;
        }
    }
}

