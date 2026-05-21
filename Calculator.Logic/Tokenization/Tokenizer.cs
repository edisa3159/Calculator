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
            string pattern = @"[+\-*/]?\s*([+-]?(?:\d+\.?\d*|\.\d+))\s*[+\-*/]?";

            // Find all matches
            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine($"Expression: {input}");
            Console.WriteLine("Extracted Numbers:\n");

            foreach (Match match in matches)
            {
                if (match.Groups[1].Success)
                {
                    string number = match.Groups[1].Value;
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine(input);
            return tokenizedInput;
        }

    }
}
