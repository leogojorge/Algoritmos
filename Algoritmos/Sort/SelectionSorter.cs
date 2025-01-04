namespace Algoritmos.Sort
{
    public class SelectionSorter
    {
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
    }
}
