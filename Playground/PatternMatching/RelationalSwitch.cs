namespace PatternMatching
{
    public class RelationalSwitch
    {
        public string Name { get; set; } = "Random";

        public string SomeVal(int age) => age switch
        {
            < 5 => "too young",
            > 65 => "too old",
            _ => this.Name
        };

        public string Testing(int age, string name) => (age, name) switch
        {

        };
    }
}
