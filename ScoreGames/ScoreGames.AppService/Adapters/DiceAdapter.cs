using ScoreGames.Domain.Entities.Dices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreGames.AppService.Adapters
{
    public class DiceAdapter
    {
        public static Dice New(int diceNum)
        {
            return DiceFactory.CreateDice(diceNum);
        }

        public static IEnumerable<Dice> NewRange(IEnumerable<int> values)
        {
            return values.Select(v => DiceFactory.CreateDice(v));
        }

        public static IEnumerable<int> DicesToInt(IEnumerable<Dice> dices)
        {
            return dices.Select(d => d.Value);
        }
    }
}
