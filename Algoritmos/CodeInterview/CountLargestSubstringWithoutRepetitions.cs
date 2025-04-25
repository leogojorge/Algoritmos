namespace Algoritmos.CodeInterview
{
    ///code interview
    ///they gave me a word and i have to check what is the biggest substring of it without repeating a letter
    ///for exemple, abcabcabc. the biggest substring is "abc" with 3 letters
    ///other exemple. pwwke. we have "pw" with 2 and "wke" with 3. we have to return 3 from the wke substring
    public class CountLargestSubstringWithoutRepetitions
    {
        public static int countLargestSubstringLetters(string word)
        {
            var hash = new HashSet<int>();

            int biggestLength = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];

                bool elementWasAdded = hash.Add(letter);

                if (elementWasAdded == false)
                {
                    if (hash.Count > biggestLength)
                        biggestLength = hash.Count;

                    hash.Clear();

                    i--;
                }
                else if (i + 1 == word.Length)
                {
                    if (hash.Count > biggestLength)
                        biggestLength = hash.Count;
                }
            }

            return biggestLength;
        }

        public void Run()
        {
            var x1 = countLargestSubstringLetters("abcabcabc");
            var x2 = countLargestSubstringLetters("bbbbbbbbb");
            var x3 = countLargestSubstringLetters("pwwke");
        }
    }
}
