using ErtsModel.Enums;

namespace ErtsModel.Entities.Lol
{
    public class LolGamePlayer : ModelBase
    {
        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
        public LolRole Role { get; set; }
        public virtual LolChampion Champion { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestMultiKill { get; set; }
        public int Level { get; set; }
        public int MagicDamageDealt { get; set; }
        public int MagicDamageDealtToChamps { get; set; }
        public int PhysicalDamageDealt { get; set; }
        public int PhysicalDamageDealtToChamps { get; set; }
        public int TrueDamageDealt { get; set; }
        public int TrueDamageDealtToChamps { get; set; }
        public int DamageDealt { get; set; }
        public int DamageDealtToChamps { get; set; }
        public int DamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int TotalTimeCrowdControlDealt { get; set; }
        public int WardsPlaced { get; set; }
        public int WardsDestroyed { get; set; }
        public int TurretsDestroyed { get; set; }
        public int InhibitorsDestroyed { get; set; }
        public int MinionsKilled { get; set; }
        public int NeutralMinionsKilled { get; set; }
        public int EnemyNeutralMinionsKilled { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstBloodAssist { get; set; }
        public virtual LolSpell Spell1 { get; set; }
        public virtual LolSpell Spell2 { get; set; }

    }
}
