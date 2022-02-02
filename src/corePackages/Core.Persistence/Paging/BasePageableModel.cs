namespace Core.Persistence.Paging
{
    public class BasePageableModel
    {
        public int Index { get; }
        public int Size { get; }
        public int Count { get; }
        public int Pages { get; }

        public bool HasPrevious { get; }
        public bool HasNext { get; }
    }
}
