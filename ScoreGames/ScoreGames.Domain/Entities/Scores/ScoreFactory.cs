using ScoreGames.Domain.Entities.BaseItems;
using ScoreGames.Domain.Interfaces.Factories;
using System.Collections.Generic;
using System.Linq;

namespace ScoreGames.Domain.Entities.Scores
{
    public abstract class ScoreFactory<T, TValue, SValue>: IScoreFactory<T, SValue> where T : IItem<TValue>
    {
        protected List<ScoreClass<T, TValue, SValue>> _scoreClasses;
        public List<ScoreClass<T, TValue, SValue>> ScoreClasses
        {
            get
            {
                if (_scoreClasses == null) InitScoreClasses();
                return _scoreClasses;
            }
        }

        protected abstract void InitScoreClasses();

        public IEnumerable<Score<T, SValue>> GetScores()
        {
            return null;
        }

        public IEnumerable<Score<T, SValue>> GetScoresByMove(IEnumerable<T> move)
        {
            return ScoreClasses.Where(s => s.PossibleMove(move))
                .Select(s => new Score<T, SValue>()
                {
                    Description = s.Description,
                    Move = s.ScorePlay(move),
                    Value = s.ScoreValue(move)
                })
                .OrderByDescending(s => s.Value);
        }
    }
}
