using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public class BalancedBrackets
    {
        private Dictionary<char, char> BracketPairs => new Dictionary<char, char>
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' },
        };

        public string[] CheckBracketBalance_V1(string[] input)
        {
            var numOfStringsOfBrackets = int.Parse(input[0]);
            var output = new string[numOfStringsOfBrackets];
            for (var i = 1; i <= numOfStringsOfBrackets; i++)
            {
                var brackets = input[i].ToCharArray();
                if (brackets.Length % 2 != 0)
                {
                    output[i - 1] = "NO";
                    continue;
                }

                var openBracketQueue = new Queue<char>();
                var closeBracketStack = new Stack<char>();
                foreach (var bracket in brackets)
                {
                    if (BracketPairs.ContainsKey(bracket))
                        openBracketQueue.Enqueue(bracket);
                    else
                        closeBracketStack.Push(bracket);
                }

                var isBalanced = true;
                while (openBracketQueue.Any() && closeBracketStack.Any())
                {
                    var openBracket = openBracketQueue.Dequeue();
                    var closeBracket = closeBracketStack.Pop();
                    if (BracketPairs[openBracket] != closeBracket)
                    {
                        isBalanced = false;
                        break;
                    }
                }

                if (isBalanced)
                    output[i - 1] = "YES";
                else
                    output[i - 1] = "NO";
            }

            return output;
        }

        public string[] CheckBracketBalance_V2(string[] input)
        {
            var numOfStringsOfBrackets = int.Parse(input[0]);
            var output = new string[numOfStringsOfBrackets];
            for (var i = 1; i <= numOfStringsOfBrackets; i++)
            {
                var brackets = input[i].ToCharArray();
                if (brackets.Length % 2 != 0)
                {
                    output[i - 1] = "NO";
                    continue;
                }

                var bracketStack = new Stack<char>();
                var isBalanced = true;
                foreach (var bracket in brackets)
                {
                    if (BracketPairs.ContainsKey(bracket))
                        bracketStack.Push(bracket);
                    else
                    {
                        var openBracket = bracketStack.Pop();
                        var closeBracket = BracketPairs[openBracket];
                        if (closeBracket != bracket)
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                }

                if (isBalanced)
                    output[i - 1] = "YES";
                else
                    output[i - 1] = "NO";
            }

            return output;
        }
    }
}