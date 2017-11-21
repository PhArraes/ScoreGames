using ScoreGames.Domain.Entities.BaseItems;
using ScoreGames.Domain.Entities.Scores;
using ScoreGames.Domain.Interfaces.Factories;
using ScoreGames.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ScoreGames.Domain.Services
{
    public abstract class BaseScoreAssistentService<T, TValue, SValue> : IBaseScoreAssistentService<T, TValue, SValue>
        where T : BaseItem<TValue>
    {
        private readonly IScoreFactory<T, SValue> _scoreFactory;

        public BaseScoreAssistentService(IScoreFactory<T, SValue> scoreFactory)
        {
            _scoreFactory = scoreFactory;
        }

        public virtual IEnumerable<Score<T, SValue>> GetPossibleScoresByMove(IEnumerable<T> move)
        {
            return _scoreFactory.GetScoresByMove(move);
        }

    }
}
