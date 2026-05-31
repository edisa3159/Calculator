namespace Calculator.Logic.Shared
{
    public static class AssociativityMapping
    {
        public readonly static Dictionary<char, string[]> AssociativityMap = new()
        {
            { 'L', new string[] { "+", "-", "*", "/" } },
            { 'R', new string[] { "^" } }
        };
    }
}
