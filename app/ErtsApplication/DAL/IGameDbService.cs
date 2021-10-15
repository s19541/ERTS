﻿using ErtsApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErtsApplication.DAL {
    public interface IGameDbService {
        ActionResult<IEnumerable<LolGameFullStatsDto>> GetLolGameStats(int gameId);
    }
}
