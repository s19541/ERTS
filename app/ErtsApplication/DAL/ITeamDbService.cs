using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ErtsApplication.DAL {
    public interface ITeamDbService {
        ActionResult<TeamDto> GetTeam(int teamId);
    }
}
