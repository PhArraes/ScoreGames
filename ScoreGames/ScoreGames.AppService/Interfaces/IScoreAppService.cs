using ScoreGames.AppService.ViewModels;
using System.Collections.Generic;

namespace ScoreGames.AppService.Interfaces
{
    public interface IScoreAppService
    {
        IEnumerable<AuroraScoreViewModel> GetScoresByMove(IEnumerable<int> move);
    }
}
