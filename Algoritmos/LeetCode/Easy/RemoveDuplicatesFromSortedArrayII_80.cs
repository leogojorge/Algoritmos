namespace Algoritmos.LeetCode.Easy
{
    public class RemoveDuplicatesFromSortedArrayII_80
    {
        // 1,1,1,2,2,3
        // 1,1,2,2,2,3
        //i =5
        //current =5
        //count=1
        public static int RemoveDuplicates(int[] nums)
        {
            int currentPosition = 1;
            int countRepetitions = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    countRepetitions = 0;
                    nums[currentPosition] = nums[i];
                    currentPosition++;
                }
                else
                {
                    countRepetitions++;
                    bool isFirstRepitition = countRepetitions <= 1;
                    if (isFirstRepitition)
                    {
                        nums[currentPosition] = nums[i];
                        currentPosition++;
                    }
                }
            }

            return currentPosition;
        }
    }
}
