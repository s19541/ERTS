using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface ITournamentDbService {
        ActionResult<IEnumerable<TournamentShortDto>> GetTournamentsShort(int serieId);
        ActionResult<IEnumerable<TournamentTeamShortDto>> GetTournamentTeamsShort(int tournamentId);
        ActionResult<IEnumerable<LolTournamentPlayerStatsDto>> GetLolTournamentPlayerStats(int tournamentId);
        ActionResult<IEnumerable<LolTournamentTeamStatsDto>> GetLolTournamentTeamStats(int tournamentId);
    }
}
