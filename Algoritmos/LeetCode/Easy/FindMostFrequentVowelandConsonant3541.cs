using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class FindMostFrequentVowelandConsonant3541
    {
        public static void Call()
        {
            string s = "bx";
            var response = MaxFreqSum(s);
        }

        public static int MaxFreqSum(string s)
        {
            var vogFreq = new Dictionary<char, int>();
            vogFreq.Add('a', 0);
            vogFreq.Add('e', 0);
            vogFreq.Add('i', 0);
            vogFreq.Add('o', 0);
            vogFreq.Add('u', 0);

            var consonantFreq = new Dictionary<char, int>();
            int freqOfVogMost = 0;
            int freqOfConsMost = 0;

            foreach (var c in s)
            {
                bool isVog = vogFreq.ContainsKey(c);

                if (isVog)
                {
                    vogFreq[c] += 1;

                    if (freqOfVogMost < vogFreq[c])
                        freqOfVogMost = vogFreq[c];
                }
                else
                {
                    bool containsCons = consonantFreq.ContainsKey(c);
                    if (containsCons)
                    {
                        consonantFreq[c] += 1;
                        if (freqOfConsMost < consonantFreq[c])
                            freqOfConsMost = consonantFreq[c];
                    }
                    else
                    {
                        consonantFreq.Add(c, 1);
                        if (freqOfConsMost == 0) freqOfConsMost++;
                    }
                }
            }

            return freqOfConsMost + freqOfVogMost;
        }
    }
}
