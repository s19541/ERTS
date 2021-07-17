namespace ErtsModel.Entities.Lol
{
    public class LolGamePlayerItem : ModelBase
    {
        public virtual LolItem Item { get; set; }
        public virtual LolGamePlayer GamePlayer { get; set; }
    }
}
