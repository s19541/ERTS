using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL
{
    public class TournamentDbService : ITournamentDbService
    {
        public ErtsContext Context { get; set; }
        public TournamentDbService(ErtsContext dbContext)
        {
            Context = dbContext;
        }
        public ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int leagueId)
        {
            List<TournamentShortDto> tournamentShortDtos = new List<TournamentShortDto>();
            var tournamentIds = Context.Tournaments.Where(o => o.League.Id == leagueId).Select(o => o.Id).ToList();

            foreach (int tournamentId in tournamentIds)
            {
                var tournamentShortDto = new TournamentShortDto()
                {
                    Id = tournamentId,
                    Name = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.Name).FirstOrDefault(),
                    StartTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.StartTime).FirstOrDefault(),
                    EndTime = Context.Tournaments.Where(p => p.Id == tournamentId).Select(p => p.EndTime).FirstOrDefault()
                };
                tournamentShortDtos.Add(tournamentShortDto);
            }
            return tournamentShortDtos;
        }

        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId)
        {
            List<TournamentTeamShortDto> tournamentTeamShortDtos = new List<TournamentTeamShortDto>();
            var tournamentTeamIds = Context.TournamentTeams.Where(o => o.Tournament.Id == tournamentId).Select(o => o.Id).ToList();

            foreach (int tournamentTeamId in tournamentTeamIds)
            {
                var teamId = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.Team.Id).FirstOrDefault();
                var tournamentTeamShortDto = new TournamentTeamShortDto()
                {
                    SeriesWon = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.SeriesWon).FirstOrDefault(),
                    SeriesLost = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.SeriesLost).FirstOrDefault(),
                    GamesWon = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesWon).FirstOrDefault(),
                    GamesLost = Context.TournamentTeams.Where(p => p.Id == tournamentTeamId).Select(p => p.GamesLost).FirstOrDefault(),
                    TeamName = Context.Teams.Where(p => p.Id == teamId).Select(p => p.Name).FirstOrDefault(),
                    TeamImageUrl = Context.Teams.Where(p => p.Id == teamId).Select(p => p.ImageUrl).FirstOrDefault()
                };
                tournamentTeamShortDtos.Add(tournamentTeamShortDto);
            }
            tournamentTeamShortDtos = tournamentTeamShortDtos.OrderByDescending(x => x.SeriesWon).ThenBy(x => x.GamesLost).ToList();
            return tournamentTeamShortDtos;
        }
    }
}
