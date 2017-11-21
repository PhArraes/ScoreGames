using ScoreGames.AppService.Adapters;
using ScoreGames.AppService.Interfaces;
using ScoreGames.AppService.ViewModels;
using ScoreGames.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ScoreGames.AppService
{
    public class ScoreAppService : IScoreAppService
    {
        private readonly IAuroraAssistantService _auroraAssistentService;

        public ScoreAppService(IAuroraAssistantService auroraAssistentService)
        {
            _auroraAssistentService = auroraAssistentService;
        }

        public IEnumerable<int> GetScores()
        {
            return null;
        }

        public IEnumerable<AuroraScoreViewModel> GetScoresByMove(IEnumerable<int> move)
        {
            var result = _auroraAssistentService.GetPossibleScoresByMove(DiceAdapter.NewRange(move));
            return result.Select(s => ScoreAdapter.ScoreToAuroraScoreVM(s));
        }


    }
}
