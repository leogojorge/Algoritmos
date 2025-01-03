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

                Console.WriteLine("List being sorted " + ArrayAsString(list));
                Console.WriteLine("List length " + list.Length);
                Console.WriteLine();

                var sortedWithSelection = SelectionSort(listForSelection, out int timesPerformedTheSwapForSelectionSort, out int timesNotPerformedTheSwapForSelectionSort, out int timesCheckedForSelectionSort);
                var sortedWithBubble = BubbleSort(listForBubble, out int timesPerformedTheSwapForBubbleSort, out int timesNotPerformedTheSwapForBubbleSort, out int timesCheckedForBubbleSort);

                Console.WriteLine("List sorted with selection - " + ArrayAsString(sortedWithSelection));
                Console.WriteLine("List sorted with bubble - " + ArrayAsString(sortedWithBubble));
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
                Console.WriteLine("Next iteration");
            }
        }

        public static int[] BubbleSort(int[] list, out int timesPerformedTheSwap, out int timesNotPerformedTheSwap, out int timesChecked)
        {
            timesPerformedTheSwap = 0;
            timesNotPerformedTheSwap = 0;
            timesChecked = 0;

            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int currentIndex = 0; currentIndex < list.Length - 1; currentIndex++)
                {
                    timesChecked++;

                    int indexNextToTheCurrent = currentIndex + 1;

                    if (list[currentIndex] < list[indexNextToTheCurrent])
                    {
                        timesNotPerformedTheSwap++;
                        continue;
                    }

                    (list[currentIndex], list[indexNextToTheCurrent]) = (list[indexNextToTheCurrent], list[currentIndex]); //usando tupla para trocar valores sem temp
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
