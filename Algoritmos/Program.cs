using System.Reflection;
using System.Text;

namespace Algoritmos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allLists = new List<int[]>
            {
                new[] { 5, 4, 3, 2, 1 },
                new[] { 9, 4, 6, 2, 7 },
                new[] { 7, 5, 1, 8, 3, 3, 3, 8, 9, 1, 10 },
                new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            };

            foreach (var list in allLists)
            {
                int[] listForSelection = (int[])list.Clone();
                int[] listForBubble = (int[])list.Clone();
                int[] listForInsertion = (int[])list.Clone();
                int[] listForMerge = (int[])list.Clone();

                Console.WriteLine("List being sorted " + ArrayAsString(list));
                Console.WriteLine("List length " + list.Length);
                Console.WriteLine();

                var sortedWithSelection = SelectionSort(listForSelection, out int timesPerformedTheSwapForSelectionSort, out int timesNotPerformedTheSwapForSelectionSort, out int timesCheckedForSelectionSort);
                var sortedWithBubble = BubbleSort(listForBubble, out int timesPerformedTheSwapForBubbleSort, out int timesNotPerformedTheSwapForBubbleSort, out int timesCheckedForBubbleSort);
                var sortedWithInsertion = InsertionSort(listForInsertion, out int timesPerformedTheSwapForInsertionSort, out int timesNotPerformedTheSwapForInsertionSort, out int timesCheckedForInsertionSort);
                MergeSort(listForMerge);

                Console.WriteLine("List sorted with selection - " + ArrayAsString(sortedWithSelection));
                Console.WriteLine("List sorted with bubble    - " + ArrayAsString(sortedWithBubble));
                Console.WriteLine("List sorted with insertion - " + ArrayAsString(sortedWithInsertion));
                Console.WriteLine("List sorted with merge     - " + ArrayAsString(listForMerge));
                Console.WriteLine();

                Console.WriteLine("Selection Sort Results:");
                Console.WriteLine("TimesPerformedTheSwap " + timesPerformedTheSwapForSelectionSort);
                Console.WriteLine("TimesNotPerformedTheSwap " + timesNotPerformedTheSwapForSelectionSort);
                Console.WriteLine("TimesChecked " + timesCheckedForSelectionSort);

                Console.WriteLine();

                Console.WriteLine("Bubble Sort Results:");
                Console.WriteLine("TimesPerformedTheSwap " + timesPerformedTheSwapForBubbleSort);
                Console.WriteLine("TimesNotPerformedTheSwap " + timesNotPerformedTheSwapForBubbleSort);
                Console.WriteLine("TimesChecked " + timesCheckedForBubbleSort);

                Console.WriteLine();

                Console.WriteLine("Insertion Sort Results:");
                Console.WriteLine("TimesPerformedTheSwap " + timesPerformedTheSwapForInsertionSort);
                Console.WriteLine("TimesNotPerformedTheSwap " + timesNotPerformedTheSwapForInsertionSort);
                Console.WriteLine("TimesChecked " + timesCheckedForInsertionSort);

                Console.WriteLine();
                Console.WriteLine("Next iteration **************************");
            }
        }

        public static void MergeSort(int[] list, int startIndex = 0, int endIndex = 0)//3
        {
            if (endIndex == 0)
                endIndex = list.Length; //1

            bool stillRemainMoreThanOneItemInTheList = endIndex - startIndex > 1;

            if (stillRemainMoreThanOneItemInTheList)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                MergeSort(list, startIndex, middleIndex);//left half 0 , 1
                MergeSort(list, middleIndex, endIndex);  //right half 1 , 3
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
                if (rightListCurrentIndex >= rightList.Length)
                {
                    list[i] = leftList[leftListCurrentIndex];
                    leftListCurrentIndex++;
                }
                else if (leftListCurrentIndex >= leftList.Length)
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


        //insere o menor item no início da lista, como se fosse uma pessoa ordenando as cartas na mão em um jogo de baralho. começa comparando a segunda carta com a primeira. depois a terceira com a segunda, caso troque, a segunda com a primeira novamente e assim por diante.
        public static int[] InsertionSort(int[] list, out int timesPerformedTheSwap, out int timesNotPerformedTheSwap, out int timesChecked)
        {
            timesPerformedTheSwap = 0;
            timesNotPerformedTheSwap = 0;
            timesChecked = 0;

            for (int i = 1; i < list.Length; i++)
            {
                int currentIndexValue = list[i];

                for (int indexToBeCompared = i - 1; indexToBeCompared >= 0; indexToBeCompared--)
                {
                    timesChecked++;

                    if (currentIndexValue > list[indexToBeCompared])
                    {
                        timesNotPerformedTheSwap++;
                        continue;
                    }

                    int temp = list[indexToBeCompared + 1];
                    list[indexToBeCompared + 1] = list[indexToBeCompared];
                    list[indexToBeCompared] = temp;

                    timesPerformedTheSwap++;
                }
            }

            return list;
        }

        public static int[] BubbleSort(int[] list, out int timesPerformedTheSwap, out int timesNotPerformedTheSwap, out int timesChecked)
        {
            timesPerformedTheSwap = 0;
            timesNotPerformedTheSwap = 0;
            timesChecked = 0;

            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int indexToBeCompared = 0; indexToBeCompared < list.Length - 1; indexToBeCompared++)
                {
                    timesChecked++;

                    int indexNextToTheCurrent = indexToBeCompared + 1;

                    if (list[indexToBeCompared] < list[indexNextToTheCurrent])
                    {
                        timesNotPerformedTheSwap++;
                        continue;
                    }

                    (list[indexToBeCompared], list[indexNextToTheCurrent]) = (list[indexNextToTheCurrent], list[indexToBeCompared]); //usando tupla para trocar valores sem temp
                    timesPerformedTheSwap++;
                }

            }

            return list;
        }

        public static int[] SelectionSort(int[] list, out int timesPerformedTheSwap, out int timesNotPerformedTheSwap, out int timesChecked)
        {
            timesPerformedTheSwap = 0;
            timesNotPerformedTheSwap = 0;
            timesChecked = 0;

            for (int indexToRecieveNextMinValue = 0; indexToRecieveNextMinValue < list.Length - 1; indexToRecieveNextMinValue++)
            {
                for (int indexToBeChecked = indexToRecieveNextMinValue + 1; indexToBeChecked < list.Length; indexToBeChecked++)
                {
                    timesChecked++;

                    if (list[indexToRecieveNextMinValue] < list[indexToBeChecked])
                    {
                        timesNotPerformedTheSwap++;
                        continue;
                    }

                    int temp = list[indexToRecieveNextMinValue];
                    list[indexToRecieveNextMinValue] = list[indexToBeChecked];
                    list[indexToBeChecked] = temp;

                    timesPerformedTheSwap++;
                }
            }

            return list;
        }

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

        public static string ArrayAsString(int[] array)
        {
            StringBuilder result = new StringBuilder();

            foreach (int i in array)
            {
                result.Append(i.ToString());
            }

            return result.ToString();
        }
    }
}
