using Calculator.Logic.Shared;

namespace Calculator.Logic
{
    public static class InfixToPostfixConvertor
    {
        public static List<string> ConvertInfixToPostfix(List<Token> infixTokens)
        {
            Stack<string> operatorStack = new Stack<string>();   // Local stack - no static
            List<string> postfix = new List<string>();           // Local result

            foreach (var token in infixTokens)
            {
                string value = token.Value?.Trim();
                if (string.IsNullOrEmpty(value)) continue;

                if (IsOperand(value))
                {
                    postfix.Add(value);
                }
                else if (value == "(")
                {
                    operatorStack.Push(value);
                }
                else if (value == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0)
                        operatorStack.Pop(); // discard '('
                }
                else if (IsOperator(value))
                {
                    while (operatorStack.Count > 0)
                    {
                        string top = operatorStack.Peek();
                        if (top == "(") break;

                        int incomingPrec = token.precedenceScore;
                        int topPrec = PrecedenceMapping.precedenceMap[top];

                        bool shouldPop = (incomingPrec < topPrec) ||
                                       (incomingPrec == topPrec && token.associativity == 'L');

                        if (!shouldPop) break;

                        postfix.Add(operatorStack.Pop());
                    }

                    operatorStack.Push(value);
                }
            }

            // Final cleanup - pop remaining operators
            while (operatorStack.Count > 0)
            {
                string op = operatorStack.Pop();
                if (op != "(" && op != ")")
                    postfix.Add(op);
            }
            Console.WriteLine("Postfix: " + string.Join(" ", postfix));
            return postfix;
        }

        public static bool IsOperator(string token)
            => PrecedenceMapping.precedenceMap.ContainsKey(token);

        public static bool IsOperand(string token)
            => double.TryParse(token, out _);
    }
}