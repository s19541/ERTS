using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase {
        private readonly ITournamentDbService _dbService;
        public TournamentController(ITournamentDbService dbService) {
            _dbService = dbService;
        }
        [Route("[action]/{serieId}")]
        [HttpGet]
        public ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int serieId) {
            return _dbService.GetTournamentsShort(serieId);
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId) {
            return _dbService.GetTournamentTeamsShort(tournamentId);
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId) {
            return _dbService.GetLolTournamentPlayerStats(tournamentId);
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<LolTournamentTeamStatsDto>> GetLolTournamentTeamStats(int tournamentId) {
            return _dbService.GetLolTournamentTeamStats(tournamentId);
        }
    }
}
