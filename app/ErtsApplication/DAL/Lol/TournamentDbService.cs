using ErtsApplication.DTO;
using ErtsModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApplication.DAL.Lol
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
    }
}
