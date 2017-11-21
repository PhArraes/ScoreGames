using ScoreGames.Domain.Entities.Cards;
using ScoreGames.Domain.Entities.Poker;

namespace ScoreGames.Domain.Services
{
    public class PokerAssistentService : BaseScoreAssistentService<Card, int, int>
    {
        public PokerAssistentService(ScorePokerFactory scoreFactory)
            : base(scoreFactory)
        {
        }
        
    }
}
