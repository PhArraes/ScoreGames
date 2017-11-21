using ScoreGames.Domain.Entities.BaseItems;
using ScoreGames.Domain.Entities.Scores;
using System.Collections.Generic;

namespace ScoreGames.Domain.Interfaces.Services
{
    public interface IBaseScoreAssistentService<T, TValue, SValue> where T : BaseItem<TValue>
    {
        IEnumerable<Score<T, SValue>> GetPossibleScoresByMove(IEnumerable<T> move);
    }
}
