using ErtsModel.Enums;

namespace ErtsModel.Entities.Lol
{
    public class LolGameTeam : ModelBase
    {
        public virtual Team Team { get; set; }
        public virtual Game Game { get; set; }
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
        public LolColor Color { get; set; }
        public virtual LolChampion Ban1 { get; set; }
        public virtual LolChampion Ban2 { get; set; }
        public virtual LolChampion Ban3 { get; set; }
        public virtual LolChampion Ban4 { get; set; }
        public virtual LolChampion Ban5 { get; set; }
        public bool FirstBaron { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstDragon { get; set; }
        public bool FirstTurret { get; set; }
        public bool FirstInhibitor { get; set; }
    }
}
