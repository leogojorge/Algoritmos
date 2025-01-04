namespace Algoritmos.Sort
{
    public class BubbleSorter
    {
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
    }
}
