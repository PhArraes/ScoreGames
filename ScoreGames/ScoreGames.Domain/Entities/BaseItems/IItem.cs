namespace ScoreGames.Domain.Entities.BaseItems
{
    public interface IItem<TValue>
    {
        int Compare(IItem<TValue> item2);
        TValue Value { get; set; }
    }
}
