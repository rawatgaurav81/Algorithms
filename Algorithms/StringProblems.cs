
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StringProblems
    {
        public static string Reverse(string s)
        {
            char[] allChars = s.ToCharArray();
            ReverseRecursively(allChars, 0, allChars.Length - 1);
            return new string(allChars);
        }
        private static void ReverseRecursively(char[] allChars,int start,int end)
        {
            if (start >= end) return;
            char temp = allChars[end];
            allChars[end] = allChars[start];
            allChars[start] = temp;
            ReverseRecursively(allChars, start + 1, end - 1);
        }
    }
}
