using System.Collections.Generic;

namespace ScoreGames.Domain.Entities.BaseItems
{
    public abstract class BaseItem<T> : IItem<T>
    {
        private string _description = null;
        public string Description
        {
            get { return _description; }
            set {  _description = value; }
        }
        public T Value { get; set; }

        public BaseItem(string description, T value)
        {
            Description = description;
            Value = value;
        }

        public int Compare(IItem<T> item2)
        {
            if (item2 == null)
                throw new System.Exception("Null compare on BaseItem.");
            return Comparer<T>.Default.Compare(Value, item2.Value);
        }
    }
}
