using ErtsApplication.DAL;
using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ErtsWebApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase {
        private readonly ITeamDbService _dbService;
        public TeamController(ITeamDbService dbService) {
            _dbService = dbService;
        }

        [Route("[action]/{teamId}")]
        [HttpGet]
        public ActionResult<TeamDto> GetTeam(int teamId) {
            return _dbService.GetTeam(teamId);
        }

        [Route("[action]/{gameType}")]
        [HttpGet]
        public ActionResult<IEnumerable<TeamImageDto>> GetTeamImages(string gameType, string fragment) {
            return _dbService.GetTeamImages((GameType)Enum.Parse(typeof(GameType), gameType), fragment);
        }
    }
}