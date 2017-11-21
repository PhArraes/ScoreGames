using ScoreGames.Domain.Entities.Scores;
using System.Collections.Generic;

namespace ScoreGames.Domain.Interfaces.Factories
{
    public interface IScoreFactory<T, SValue>
    {
        IEnumerable<Score<T, SValue>> GetScoresByMove(IEnumerable<T> move);
    }
}
