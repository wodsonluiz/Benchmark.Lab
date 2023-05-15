using System.Collections.Generic;
using System.Linq;

namespace Elapsed_n_memory
{
    public static class SumCalculator
    {
        public static int SumWithEnumerator(this IEnumerable<int> enumerable)
        {
            int sum = 0;

            IEnumerator<int> enumerator = enumerable.GetEnumerator();

            try
            {
                while(enumerator.MoveNext())
                {
                    sum += enumerator.Current;
                }
            }
            finally
            {
                enumerator.Dispose();
            }

            return sum;
        }
    
        public static int SumWithFor(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static int SumWithLinq(this int[] array)
        {
            return array.Sum();
        }
    }
}