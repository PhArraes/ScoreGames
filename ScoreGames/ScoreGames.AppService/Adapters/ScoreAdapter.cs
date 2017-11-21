using ScoreGames.AppService.ViewModels;
using ScoreGames.Domain.Entities.Dices;
using ScoreGames.Domain.Entities.Scores;
using System.Linq;

namespace ScoreGames.AppService.Adapters
{
    public class ScoreAdapter
    {
        public static AuroraScoreViewModel ScoreToAuroraScoreVM(Score<Dice, int> score)
        {
            return new AuroraScoreViewModel() { Description = score.Description, Value = score.Value, Move = DiceAdapter.DicesToInt(score.Move).OrderBy(m => m) };
        }
    }
}
