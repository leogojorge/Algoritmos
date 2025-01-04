using Algoritmos.Data;
using Algoritmos.Sort;
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
                IntArrayGenerator.Generate(200, 0, 10000)
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

                SelectionSorter.SelectionSort(listForSelection, out int timesPerformedTheSwapForSelectionSort, out int timesNotPerformedTheSwapForSelectionSort, out int timesCheckedForSelectionSort);
                BubbleSorter.BubbleSort(listForBubble, out int timesPerformedTheSwapForBubbleSort, out int timesNotPerformedTheSwapForBubbleSort, out int timesCheckedForBubbleSort);
                InsertionSorter.InsertionSort(listForInsertion, out int timesPerformedTheSwapForInsertionSort, out int timesNotPerformedTheSwapForInsertionSort, out int timesCheckedForInsertionSort);
                MergeSorter.MergeSort(listForMerge);

                Console.WriteLine("List sorted with selection - " + ArrayAsString(listForSelection));
                Console.WriteLine("List sorted with bubble    - " + ArrayAsString(listForBubble));
                Console.WriteLine("List sorted with insertion - " + ArrayAsString(listForInsertion));
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

        public static string ArrayAsString(int[] array)
        {
            StringBuilder result = new StringBuilder();

            foreach (int i in array)
            {
                result.Append(i);
                result.Append(',');
            }

            return result.ToString();
        }
    }
}
