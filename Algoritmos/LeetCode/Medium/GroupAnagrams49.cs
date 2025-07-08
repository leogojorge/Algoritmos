using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Medium
{
    public static class GroupAnagrams49
    {
        public static void Call()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var result = GroupAnagrams(strs);
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anag = new Dictionary<string, List<string>>();

            foreach (var word in strs)
            {
                char[] charX = word.ToCharArray();
                Array.Sort(charX);
                string wordSorted = new string(charX);

                if (anag.ContainsKey(wordSorted))
                    anag[wordSorted].Add(word);
                else
                    anag[wordSorted] = new List<string> { word };
            }

            return anag.Values.Select(list => (IList<string>)list).ToList();
        }
    }
}
