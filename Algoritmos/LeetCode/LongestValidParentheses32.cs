using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode
{
    public static class LongestValidParentheses32
    {
        public static void Call()
        {
            string s = "({[)";

            bool result = IsValid(s);
        }

        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            int result = 0;
            int lastMatch = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(s[i]);
                    lastMatch = 0;
                    continue;
                }

                stack.TryPeek(out char lastCharAdded);

                if (lastCharAdded == '(' && s[i] == ')')
                {
                    result += 2;
                    lastMatch = s[i];
                }
            }

            return result == 0;
        }
    }
}
