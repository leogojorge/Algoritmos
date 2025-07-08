namespace Algoritmos.Sort
{
    public class MergeSorter
    {
        public static int[] Sort(int[] list)
        {
            return MergeSort(list, 0, list.Length - 1);
        }

        public static int[] MergeSort(int[] list, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return list;

            int middleIndex = (startIndex + endIndex) / 2;

            MergeSort(list, startIndex, middleIndex);
            MergeSort(list, middleIndex + 1, endIndex);
            Merge(list, startIndex, middleIndex, endIndex);

            return list;
        }

        private static int[] Merge(int[] list, int startIndex, int middleIndex, int endIndex)
        {
            int[] leftSide = list[startIndex..(middleIndex + 1)];
            int[] rightSide = list[(middleIndex + 1) .. (endIndex + 1)];

            int leftIndex = 0;
            int rightIndex = 0;
            int mainIndex = startIndex;

            while (leftIndex < leftSide.Length && rightIndex < rightSide.Length) // organiza os dois lados
            {
                if (leftSide[leftIndex] <= rightSide[rightIndex])
                {
                    list[mainIndex] = leftSide[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[mainIndex] = rightSide[rightIndex];
                    rightIndex++;
                }
                mainIndex++;
            }

            while(leftIndex < leftSide.Length) //se sobrou algum item em uma das listas, positiona de volta na lista principal. pode acontecer pois uma lista pode ter mais itens que a outra
            {
                list[mainIndex] = leftSide[leftIndex];
                leftIndex++;
                mainIndex++;
            }

            while (rightIndex < rightSide.Length) //mesma coisa do de cima
            {
                list[mainIndex] = rightSide[rightIndex];
                rightIndex++;
                mainIndex++;
            }

            return list;
        }
    }
}
