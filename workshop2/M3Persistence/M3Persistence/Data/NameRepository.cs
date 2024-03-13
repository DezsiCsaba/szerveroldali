namespace M3Persistence.Data
{
    public class NameRepository : INameRepository
    {
        List<string> names;
        public NameRepository()
        {
            names = new List<string>() { "Jack", "John", "Julie" };
        }

        public void Add(string name)
        {
            this.names.Add(name);
        }

        public string List()
        {
            return String.Join(",", this.names);
        }
    }
}
