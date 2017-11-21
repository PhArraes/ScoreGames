using ScoreGames.Domain.Entities.BaseItems;

namespace ScoreGames.Domain.Entities.Cards
{
    public class Card : BaseItem<int>
    {
        public int CardId { get; set; }
        public string Suit { get; set; }

        public Card(string description, int value) : base(description, value)
        {
        }
    }
}
