namespace _01.Index
{
    public class PrivateProtectedBase
    {
        private protected string Name { get; set; } = "Pesho";

        public override string ToString()
        {
            return this.Name;
        }
    }
}
