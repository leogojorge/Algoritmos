namespace Algoritmos.Search
{
    public class BinarySearcher
    {
        public static int? BinarySearch(int[] list, int target)
        {
            int beginIndex = 0;
            int endIndex = list.Length - 1;

            return BinarySearch(list, target, beginIndex, endIndex);
        }

        public static int? BinarySearch(int[] list, int target, int beginIndex, int endIndex)
        {
            if (beginIndex > endIndex)
            {
                return null;
            }

            int halfIndex = (int)(beginIndex + endIndex) / 2;

            if (list[halfIndex] == target)
                return halfIndex;

            if (target > list[halfIndex])
                return BinarySearch(list, target, halfIndex + 1, endIndex);
            else
                return BinarySearch(list, target, beginIndex, halfIndex - 1);
        }
    }
}