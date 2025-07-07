using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class ValidParentheses20
    {
        public static void Call()
        {
            string s = "({[)";

            bool result = IsValid1(s);
            bool result2 = IsValid2(s);
        }

        public static bool IsValid1(string s)
        {
            if (s.Length % 2 == 1) return false;

            var stack = new Stack<int>();

            foreach (char currentChar in s)
            {
                stack.TryPeek(out int lastCharAdded);

                if (lastCharAdded == '[')
                {
                    if (currentChar == ']') { stack.Pop(); continue; }
                }
                else if (lastCharAdded == '(')
                {
                    if (currentChar == ')') { stack.Pop(); continue; }
                }
                else if (lastCharAdded == '{')
                {
                    if (currentChar == '}') { stack.Pop(); continue; }
                }

                stack.Push(currentChar);
            }

            return stack.Count == 0;
        }

        public static bool IsValid2(string s)
        {
            if (s.Length % 2 == 1) return false;

            var openingChars = new List<char> { '(', '{', '[' };
            var closingChars = new List<char> { ')', '}', ']' };
            var stack = new Stack<char>();

            foreach (char currentChar in s)
            {
                if (openingChars.Contains(currentChar))
                {
                    stack.Push(currentChar);
                    continue;
                }

                if (closingChars.Contains(currentChar))
                {
                    stack.TryPeek(out char lastCharAdded);

                    if (lastCharAdded == '(' && currentChar == ')') stack.Pop();
                    else if (lastCharAdded == '{' && currentChar == '}') stack.Pop();
                    else if (lastCharAdded == '[' && currentChar == ']') stack.Pop();
                    else
                        return false;
                }

            }

            return stack.Count == 0;
        }
    }
}
