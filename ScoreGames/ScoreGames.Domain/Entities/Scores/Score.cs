using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreGames.Domain.Entities.Scores
{
    public class Score<T, TValue>
    {
        public string Description { get; set; }
        public TValue Value { get; set; }
        public IEnumerable<T> Move { get; set; }
    }
}
