﻿using System;

namespace ErtsApplication.DTO {
    public class SerieShortDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
