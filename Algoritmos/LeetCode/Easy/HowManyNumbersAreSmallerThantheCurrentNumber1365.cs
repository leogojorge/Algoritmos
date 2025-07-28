using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class HowManyNumbersAreSmallerThantheCurrentNumber1365
    {
        public static void Call()
        {
            int[] nums = [8, 1, 2, 2, 3];
            var result = SmallerNumbersThanCurrent(nums);
        }
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            var numSort = nums;
            Array.Sort(numSort);

            for (int i = 0; i < nums.Length; i++)
            {
                dic.TryAdd(numSort[i], i);
            }

            var resp = new int[nums.Length];
            for (int x = 0; x < nums.Length; x++)
            {
                numSort[x] = dic[nums[x]];
            }

            return numSort;

        }
    }
}
