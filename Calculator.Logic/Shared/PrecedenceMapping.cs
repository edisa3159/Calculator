namespace Calculator.Logic.Shared
{
    public static class PrecedenceMapping
    {
        public readonly static Dictionary<string, int> precedenceMap = new()
            {
                { "+", 1 },
                { "-", 1 },
                { "*", 2 },
                { "/", 2 },
                { "^", 3 },
            };
    }
}
