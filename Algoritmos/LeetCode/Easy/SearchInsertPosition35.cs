using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos.LeetCode.Easy
{
    public static class SearchInsertPosition35
    {
        public static int Call()
        {
            int[] nums = { 1, 3, 5, 6 };
            int target = 7;

            return SearchInsert(nums,target);
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                    return result = i;
            
                if(i == nums.Length - 1)
                    return result = i+1;
            }

            return result;
        }
    }
}
