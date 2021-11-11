using ErtsApplication.DTO;
using ErtsModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface ITeamDbService {
        ActionResult<TeamDto> GetTeam(int teamId);
        ActionResult<IEnumerable<TeamImageDto>> GetTeamImages(GameType gameType, string format);
    }
}
