using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Merger
    {
        public static int[] Merge(int[] A, int[] B)
        {
            int aLength = A.Length;
            int bLength = B.Length;
            int[] result = new int[aLength + bLength];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < aLength && j < bLength)
            {
                if (A[i] < B[j])
                {
                    result[k] = A[i]; k++; i++;
                }
                else
                {
                    result[k] = B[j];k++;j++;
                }
            }
            while (i < aLength)
            {
                result[k] = A[i];k++;i++;
            }
            while (j < bLength)
            {
                result[k] = B[j];k++;j++;
            }

            return result;
        }

        
    }
}
