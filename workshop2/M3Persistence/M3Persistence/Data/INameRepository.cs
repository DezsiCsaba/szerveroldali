namespace M3Persistence.Data
{
    public interface INameRepository
    {
        void Add(string name);
        string List();
    }
}