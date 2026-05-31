using Calculator.Logic.Shared;

namespace Calculator.Logic
{
    public static class TokenListCreator
    {
        static List<string> infixTokens = new List<string>();
        static List<Token> outputTokenList = new List<Token>();

        public static List<Token> createListOfTokenObjects (List<string> infixTokens)
        {
            foreach (var token in infixTokens)
            {
                if (PrecedenceMapping.precedenceMap.ContainsKey(token))
                {
                    int precedenceScore = PrecedenceMapping.precedenceMap[token];
                    char associativity = 'L';
                    if (AssociativityMapping.AssociativityMap['R'].Contains(token))
                    {
                        associativity = 'R';
                    }
                    outputTokenList.Add(new Token(token, precedenceScore, associativity));
                }
                else
                {
                    outputTokenList.Add(new Token(token, 0, 'N'));
                }
            }
            return outputTokenList;
        }
    }
}
