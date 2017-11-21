using ScoreGames.Domain.Entities.BaseItems;

namespace ScoreGames.Domain.Entities.Dices
{
    public class Dice : BaseItem<int>
    {
        public int DiceId { get; set; }

        public Dice(string description, int value) : base(description, value)
        {
        }
    }
}
