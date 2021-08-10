using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers.Lol
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentDbService _dbService;
        public TournamentController(ITournamentDbService dbService)
        {
            _dbService = dbService;
        }
        [Route("[action]/{leagueId}")]
        [HttpGet]
        public ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int leagueId)
        {
            return _dbService.GetTournamentsShort(leagueId);
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId)
        {
            return _dbService.GetTournamentTeamsShort(tournamentId);
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId)
        {
            return _dbService.GetLolTournamentPlayerStats(tournamentId);
        }
    }
}
