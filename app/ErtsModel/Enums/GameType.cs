using System.ComponentModel;

namespace ErtsModel.Enums {
    public enum GameType {
        [Description("League of Legends")]
        lol,

        [Description("Counter-Strike Global Offensive")]
        csgo,

        [Description("Valorant")]
        valorant,

        [Description("Overwatch")]
        overwatch,

        [Description("Dota 2")]
        dota2,

        [Description("Rainbow Six Siege")]
        r6
    }
}
