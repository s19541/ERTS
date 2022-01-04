using ErtsApplication.DAL;
using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase {
        private readonly IMatchDbService _dbService;
        public MatchController(IMatchDbService dbService) {
            _dbService = dbService;
        }
        [Route("[action]/{tournamentId}")]
        [HttpGet]
        public ActionResult<IEnumerable<MatchShortDto>> GetMatches(int tournamentId) {
            return _dbService.GetMatches(tournamentId);
        }
        [Route("[action]/{matchId}")]
        [HttpGet]
        public ActionResult<MatchDto> GetMatch(int matchId) {
            return _dbService.GetMatch(matchId);
        }
    }
}
