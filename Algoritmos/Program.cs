using Algoritmos.Data;
using Algoritmos.LeetCode.Easy;
using Algoritmos.Sort;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Algoritmos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CallLeetCodeChallenges();

            RemoveElement27.RemoveElement([0],0);

            FindFirstIndex.StrStr("hello", "ll");

            int[] nums = { 1, 1, 1, 2, 2, 3, };
            //RemoveDuplicatesFromSortedArray.RemoveDuplicates(nums);
            RemoveDuplicatesFromSortedArrayII_80.RemoveDuplicates(nums);


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

        private static void CallLeetCodeChallenges()
        {
            BinaryTreeLevelOrderTraversal102.Call();
            BaseballGame682.Call();
            NextGreaterElementI496.Call();
            ValidParentheses20.Call();
            ReverseLinkedList.Call();
            PlusOne66.Call();
            SearchInsertPosition35.Call();
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
