namespace Algoritmos.Sort
{
    public class InsertionSorter
    {
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
    }
}
