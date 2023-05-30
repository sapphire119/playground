namespace AsyncAwaitInDetail
{
    public class Handler
    {
        public int DoStuff(string arg) => arg switch
        {
            "multiply" => 5 * 5,
            "add" => 5 + 5,
            "end" => 5,
            _ => 0
        };
    }
}
