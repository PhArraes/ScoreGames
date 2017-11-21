using ScoreGames.Domain.Entities.Dices;
using ScoreGames.Domain.Entities.Aurora;
using ScoreGames.Domain.Interfaces.Services;
using ScoreGames.Domain.Interfaces.Factories;

namespace ScoreGames.Domain.Services
{
    public class AuroraAssistantService : BaseScoreAssistentService<Dice, int, int>, IAuroraAssistantService
    {
        public AuroraAssistantService(IScoreAuroraFactory scoreFactory)
            : base(scoreFactory)
        {
        }
        
    }
}
