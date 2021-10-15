namespace ErtsApplication.DTO {
    public class LolGameTeamShortStatsDto {
        public long TeamId { get; set; }
        public int BaronKilled { get; set; }
        public int MountainDrakeKilled { get; set; }
        public int InfernalDrakeKilled { get; set; }
        public int OceanDrakeKilled { get; set; }
        public int CloudDrakeKilled { get; set; }
        public int ElderDrakeKilled { get; set; }
        public int HeraldKilled { get; set; }
        public int GoldEarned { get; set; }
        public int Kills { get; set; }
        public int TurretDestroyed { get; set; }
        public int InhibitorDestroyed { get; set; }
        public string Ban1ImageUrl { get; set; }
        public string Ban2ImageUrl { get; set; }
        public string Ban3ImageUrl { get; set; }
        public string Ban4ImageUrl { get; set; }
        public string Ban5ImageUrl { get; set; }

    }
}
