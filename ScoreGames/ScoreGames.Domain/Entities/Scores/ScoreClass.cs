using ScoreGames.Domain.Entities.BaseItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreGames.Domain.Entities.Scores
{
    public class ScoreClass<T, TValue, SValue> where T : IItem<TValue>
    {
        public ScoreClass()
        {

        }
        public ScoreClass(string description, Predicate<IEnumerable<T>> possibleMovePred, Func<IEnumerable<T>, SValue> scoreCalcFunc, Func<IEnumerable<T>, IEnumerable<T>> playFunc)
        {
            Description = description;
            PossibleMoveFunc = possibleMovePred;
            ScoreCalc = scoreCalcFunc;
            PlayFunc = playFunc;
        }
        public string Description { get; set; }

        public Predicate<IEnumerable<T>> PossibleMoveFunc { get => _possibleMove; set => _possibleMove = value; }
        public Func<IEnumerable<T>, SValue> ScoreCalc { get => _scoreCalc; set => _scoreCalc = value; }
        public Func<IEnumerable<T>, IEnumerable<T>> PlayFunc { get => _playFunc; set => _playFunc = value; }

        private Predicate<IEnumerable<T>> _possibleMove;
        private Func<IEnumerable<T>, SValue> _scoreCalc;
        private Func<IEnumerable<T>, IEnumerable<T>> _playFunc;

        public bool PossibleMove(IEnumerable<T> move)
        {
            if (PossibleMoveFunc == null) throw new Exception("PossibleMoveFunc is null");
            return PossibleMoveFunc(move);
        }

        public SValue ScoreValue(IEnumerable<T> move)
        {
            return ScoreCalc(move);
        }

        public IEnumerable<T> ScorePlay(IEnumerable<T> move)
        {
            return PlayFunc(move);
        }
    }
}
