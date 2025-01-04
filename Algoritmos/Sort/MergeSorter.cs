namespace Algoritmos.Sort
{
    public class MergeSorter
    {
        public static void MergeSort(int[] list, int startIndex = 0, int endIndex = 0)//3
        {
            if (endIndex == 0)
                endIndex = list.Length;

            bool stillRemainMoreThanOneItemInTheList = endIndex - startIndex > 1;

            if (stillRemainMoreThanOneItemInTheList)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                MergeSort(list, startIndex, middleIndex);//left half
                MergeSort(list, middleIndex, endIndex);  //right half
                Merge(list, startIndex, middleIndex, endIndex);
            }
        }

        private static void Merge(int[] list, int startIndex, int middleIndex, int endIndex)
        {
            int[] leftList = list[startIndex..middleIndex];
            int[] rightList = list[middleIndex..endIndex];

            int leftListCurrentIndex = 0;
            int rightListCurrentIndex = 0;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (rightListCurrentIndex >= rightList.Length)//validation to check if right side has already been fully used
                {
                    list[i] = leftList[leftListCurrentIndex];
                    leftListCurrentIndex++;
                }
                else if (leftListCurrentIndex >= leftList.Length)//validation to check if left side has already been fully used
                {
                    list[i] = rightList[rightListCurrentIndex];
                    rightListCurrentIndex++;
                }
                else if (leftList[leftListCurrentIndex] < rightList[rightListCurrentIndex])
                {
                    list[i] = leftList[leftListCurrentIndex];
                    leftListCurrentIndex++;
                }
                else
                {
                    list[i] = rightList[rightListCurrentIndex];
                    rightListCurrentIndex++;
                }
            }
        }
    }
}
