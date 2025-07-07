using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class PlusOne66
    {
        public static void Call()
        {
            int[] digits = [9,9,9,9,9,9,9,9];

            PlusOne(digits);
        }
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] + 1 == 10)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] += 1;
                    break;
                }
            }

            if (digits[0] == 0)
            {
                digits = new int[digits.Length + 1];
                digits[0] = 1;
            }

            return digits;
        }
    }
}
