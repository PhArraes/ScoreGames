using ScoreGames.Domain.Entities.Cards;
using ScoreGames.Domain.Entities.Scores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreGames.Domain.Entities.Poker
{
    public class ScorePokerFactory : ScoreFactory<Card, int, int>
    {
        protected override void InitScoreClasses()
        {
            throw new NotImplementedException();
        }
    }
}
