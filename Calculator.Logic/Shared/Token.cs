using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic.Shared
{
    public class Token
    {
        public string Value;
        public int precedenceScore;
        public char associativity;
        public Token(string value, int precedenceScore, char associativity)
        {
            Value = value;
            this.precedenceScore = precedenceScore;
            this.associativity = associativity;
        }
    }
}
