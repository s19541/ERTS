using ErtsApplication.DAL;
using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase {
        private readonly ILeagueDbService _dbService;
        public LeagueController(ILeagueDbService dbService) {
            _dbService = dbService;
        }

        [Route("[action]/{leagueId}")]
        [HttpGet]
        public ActionResult<LeagueDto> GetLeague(int leagueId) {
            return _dbService.GetLeague(leagueId);
        }

        [Route("[action]/{gameType}")]
        [HttpGet]
        public ActionResult<IEnumerable<LeagueImageDto>> GetLeagueImages(string gameType, string fragment) {
            return _dbService.GetLeagueImages((GameType)Enum.Parse(typeof(GameType), gameType), fragment);
        }
    }
}
