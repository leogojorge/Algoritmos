using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Medium
{
    public static class _3Sum
    {
        public static void Call()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 };
            var resp = ThreeSum(nums);
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //comparo os dois extremos mais um da direita pra esquerda
            //se a soma ficar negativa, ando o ponteiro da esquerda para a direita
            //se encontrar a soma zero, ando o segundo ponteiro (o da extremidade) para a esquerda e continuo

            Array.Sort(nums);
            var resp = new List<IList<int>>();

            for (int start = 0; start < nums.Length; start++)
            {
                if (start > 0 && nums[start] == nums[start - 1]) continue;

                int left = start + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[start] + nums[left] + nums[right];

                    if (sum > 0) right--;
                    else if (sum < 0) left++;
                    else if (sum == 0)
                    {
                        resp.Add(new List<int> { nums[start], nums[left], nums[right] });
                        left++;
                    }

                    while (nums[left] == nums[left - 1] && left < right) left++;
                }
            }

            return resp;
        }
    }
}
