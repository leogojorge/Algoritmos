using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class BaseballGame682
    {
        public static void Call()
        {
            var ops = new string[]{ "1", "C" };
            var responnse = CalPoints(ops);
        }
        public static int CalPoints(string[] operations)
        {
            var score = new int[operations.Length];
            int scoreLastIndex = 0;

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "+")
                {
                    int sum = score[scoreLastIndex - 1] + score[scoreLastIndex - 2];
                    score[scoreLastIndex] = sum;
                    scoreLastIndex++;
                    continue;
                }
                if (operations[i] == "D")
                {
                    int doubleNum = score[scoreLastIndex - 1] * 2;
                    score[scoreLastIndex] = doubleNum;
                    scoreLastIndex++;
                    continue;
                }
                if (operations[i] == "C")
                {
                    scoreLastIndex--;
                    continue;
                }

                score[scoreLastIndex++] = Convert.ToInt32(operations[i]);
            }

            int finalScore = 0;
            for (int x = 0; x < scoreLastIndex; x++)
                finalScore += score[x];

            return finalScore;
        }

        
    }
}
