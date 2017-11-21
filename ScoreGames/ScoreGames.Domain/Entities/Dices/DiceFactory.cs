using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreGames.Domain.Entities.Dices
{
    public class DiceFactory
    {
        private static readonly string[] _dicesDescription
            = new string[] { "Um", "Dois", "Três", "Quatro", "Cinco", "Seis" };

        public static Dice CreateDice(int value)
        {
            if (value > 0 && value < 7)
                return new Dice(_dicesDescription[value - 1], value);
            return null;
        }
    }
}
