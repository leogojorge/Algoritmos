namespace Algoritmos.Data
{
    public class IntArrayGenerator
    {
        public static int[] Generate(int size, int minNumber, int maxNumber)
        {
            int[] array = new int[size];
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(minNumber, maxNumber);
            }

            return array;
        }
    }
}
