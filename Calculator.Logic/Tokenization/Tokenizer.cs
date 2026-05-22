using System.Text.RegularExpressions;

namespace Calculator.Logic.Tokenization
{
    public class Tokenizer
    {
        public string[] tokenizedInput = {};

        public string[] TokenizeInputExpression(string input)
        {
            input = input.Trim(); //remove surrounding whitespaces
            input = Regex.Replace(input, @"\s+", ""); //remove all whitespaces for easier reading

            // The regex pattern
            string operandPattern = @"[+-]?\d+\.?\d*|\.\d+";
            string operatorPattern = @"[*/()]|[+\-](?!\d)";
            string pattern = $"({operandPattern})|({operatorPattern})";

            // Find all matches
            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine($"Expression: {input}");
            Console.WriteLine("Extracted Numbers:\n");

            foreach (Match match in matches)
            {
                    Console.WriteLine(match.Value);
                            
            }
            Console.WriteLine(input);
            return tokenizedInput;
        }

    }
}
