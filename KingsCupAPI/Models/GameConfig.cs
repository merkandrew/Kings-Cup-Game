using System.Collections.Generic;

namespace KingsCupGame.Models
{
    public class GameConfig
    {
        public int PlayerLimit { get; set; } = int.MaxValue;
        public Dictionary<string, string> CustomRules { get; set; } = new Dictionary<string, string>();
        public bool AllowDuplicates { get; set; } = true;
    }
}
