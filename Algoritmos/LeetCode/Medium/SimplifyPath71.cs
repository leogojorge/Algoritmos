using System.Text;
using Algoritmos.LeetCode.Easy;

namespace Algoritmos.LeetCode.Medium
{
    public static class SimplifyPath71
    {
        public static void Call()
        {
            string path = "/home//foo/";
            var response = SimplifyPath(path);
        }

        public static string SimplifyPath(string path)
        {
            var pathStack = new Stack<string>();

            var pathSplited = path.Split('/');

            for (int i = 0; i < pathSplited.Length; i++)
            {
                var subPath = pathSplited[i];

                if (subPath == "..")
                {
                    if (pathStack.Count != 0)
                    {
                        pathStack.Pop();
                        continue;
                    }
                }
                else if (subPath != "." && subPath != "")
                    pathStack.Push(subPath);
            }

            string result = "";

            if (pathStack.Count == 0) return "/";

            while (pathStack.Count > 0)
            {
                string subPath = "/" + pathStack.Pop();
                result = string.Concat(subPath, result);  
            }

            return result;
        }
    }
}
//Treino com Alexandre desde 2014.  Tive a honra de me tornar faixa preta com seus ensimanetos precisos e detalhados. Explica muito bem cada situação e como se defender de acordo. 