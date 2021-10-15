using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface IMatchDbService {
        ActionResult<IEnumerable<MatchDto>> GetMatches(int tournamentId);
        ActionResult<MatchDto> GetMatch(int matchId);
    }
}
