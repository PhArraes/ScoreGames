using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreGames.AppService.ViewModels
{
    public class AuroraScoreViewModel
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public IEnumerable<int> Move { get; set; }
    }
}
