using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public class Stack_BalancedBrackets
    {
        private Dictionary<char, char> BracketPairs => new Dictionary<char, char>
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' },
        };

        public string CheckBracketBalance_V1(string input)
        {
            var brackets = input.ToCharArray();
            if (brackets.Length % 2 != 0)
                return "NO";

            var openBracketQueue = new Queue<char>();
            var closeBracketStack = new Stack<char>();
            foreach (var bracket in brackets)
            {
                if (BracketPairs.ContainsKey(bracket))
                    openBracketQueue.Enqueue(bracket);
                else
                    closeBracketStack.Push(bracket);
            }

            while (openBracketQueue.Any() && closeBracketStack.Any())
            {
                var openBracket = openBracketQueue.Dequeue();
                var closeBracket = closeBracketStack.Pop();
                if (BracketPairs[openBracket] != closeBracket)
                    return "NO";
            }

            return "YES";
        }

        public string CheckBracketBalance_V2(string input)
        {
            var brackets = input.ToCharArray();
            if (brackets.Length % 2 != 0)
                return "NO";

            var bracketStack = new Stack<char>();
            foreach (var bracket in brackets)
            {
                if (BracketPairs.ContainsKey(bracket))
                    bracketStack.Push(bracket);
                else
                {
                    var openBracket = bracketStack.Pop();
                    var closeBracket = BracketPairs[openBracket];
                    if (closeBracket != bracket)
                        return "NO";
                }
            }

            return "YES";
        }
    }
}