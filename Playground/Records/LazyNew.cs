namespace Records
{
    public class LazyNew
    {
        public LazyNew(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
        public int Age { get; init; }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
