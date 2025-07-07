using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode
{
    public static class NextGreaterElementI496
    {
        public static void Call()
        {
            int[] nums1 = { 4, 1, 2 };

            int[] nums2 = { 1, 3, 4, 2 };

            var result = NextGreaterElement(nums1, nums2);
            var result2 = NextGreaterElement2(nums1, nums2);

        }
        public static int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var result = new List<int>();

            var ht = new Hashtable(nums2.Length);

            for (int j = 0; j < nums2.Length; j++)
            {
                ht.Add(nums2[j], j);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                bool keyExists = ht.ContainsKey(nums1[i]);
                if (!keyExists)
                    result.Add(-1);

                int indexOfFoundNumber = (int)ht[nums1[i]];

                for (int x = indexOfFoundNumber; x < nums2.Length; x++)
                {
                    if (nums2[x] > nums1[i])
                    {
                        result.Add(nums2[x]);
                        break;
                    }
                    if (x == nums2.Length - 1)
                        result.Add(-1);
                }
            }

            return result.ToArray();
        }

        public static IList<int> NextGreaterElement2(int[] nums1, int[] nums2)
        {
            var stack = new Stack<int>();
            var nextGreater = new Dictionary<int, int>();

            // Percorrer nums2 de trás pra frente
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                int num = nums2[i];

                // Remove do stack enquanto o topo for menor ou igual ao número atual
                while (stack.Count > 0 && num >= stack.Peek())
                {
                    stack.Pop();
                }

                // Se o stack estiver vazio, não há maior próximo
                nextGreater[num] = stack.Count > 0 ? stack.Peek() : -1;

                stack.Push(num);
            }

            // Criar a lista de saída com base nos valores de nums1
            var result = new List<int>();
            foreach (var num in nums1)
            {
                result.Add(nextGreater[num]);
            }

            return result;
        }
    }
}