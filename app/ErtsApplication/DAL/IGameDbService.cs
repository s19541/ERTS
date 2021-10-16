using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ErtsApplication.DAL {
    public interface IGameDbService {
        ActionResult<LolGameFullStatsDto> GetLolGameStats(int gameId);
    }
}
