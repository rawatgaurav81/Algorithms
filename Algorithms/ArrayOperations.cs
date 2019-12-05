
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/// This class contains all the problems that can be done on an array.
namespace Algorithms
{
    public class ArrayOperations
    {
        public int SmallestPositive(int[] A)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    if (frequencyMap.ContainsKey(A[i]))
                        frequencyMap[A[i]] += 1;
                    else
                        frequencyMap[A[i]] = 1;

                    // Also do it for maximum
                    if (frequencyMap.ContainsKey(A[i] + 1))
                        frequencyMap[A[i] + 1] += 1;
                    else
                        frequencyMap[A[i] + 1] = 1;
                }
            }
            if (frequencyMap.Count() == 0)
                return 1;
            else
                // return frequencyMap.FirstOrDefault(x => x.Value == 1).Key;
                return frequencyMap.Where(x => x.Value == 1).ToList().OrderBy(p => p.Key).FirstOrDefault().Key;
        }
        public static int hourglassSum(int[][] arr)
        {
            int maximum = Int32.MinValue; int sum = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr[i].Length - 1; j++)
                {
                    sum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];
                    if (maximum < sum) maximum = sum;
                }
            }
            return maximum;
        }
        public string NeutralizeCharges(string s)
        {
            char[] A = s.ToCharArray();
            Stack<char> stack = new Stack<char>();
            if (A.Length != 0) stack.Push(A[0]);
            for (int i = 1; i < A.Length; i++)
            {
                if (stack.Count == 0) stack.Push(A[i]);
                else
                {
                    char latest = stack.Peek();
                    if (latest == A[i])
                        stack.Pop();
                    else
                        stack.Push(A[i]);
                }
            }
            A = new char[stack.Count];
            while (stack.Count > 0)
            {
                A[stack.Count - 1] = stack.Pop();
            }
            return new string(A);
        }
        public int FindOddOneOut(int[] A)
        {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (frequencyMap.ContainsKey(A[i]))
                    frequencyMap[A[i]] += 1;
                else
                    frequencyMap[A[i]] = 1;
            }
            return frequencyMap.FirstOrDefault(x => x.Value == 1).Key;
        }
        public int FindMaxBinaryGap(int n)
        {
            int max = 0;
            int lastMax = 0;
            Boolean found = false;
            int difference = 0;
            while (n > 0)
            {
                difference = n % 2;
                if (difference == 1) found = true;
                if (found)
                {
                    if (difference > 0)
                    {
                        if (lastMax < max) lastMax = max;
                        max = 0;
                    }
                    else
                        max++;
                }
                n = n / 2;
            }
            return lastMax;
        }
        public int[] Intersect(int[] A, int[] B)
        {
            Hashtable hs = new Hashtable();
            for (int i = 0; i < A.Length; i++)
                if (!hs.ContainsKey(A[i])) hs[A[i]] = 1;

            for (int j = 0; j < B.Length; j++)
            {
                if (hs.ContainsKey(B[j])) hs[B[j]] = 2;
            }
            return hs.Keys.OfType<int>().Where(x => hs[x].ToString() == "2").ToArray();
        }
        public int FindUniqueLonelyNumber(int[] A)
        {
            Hashtable hs = new Hashtable();
            for (int i = 0; i < A.Length; i++)
                if (!hs.ContainsKey(A[i])) hs[A[i]] = 1;
                else
                    hs[A[i]] = Convert.ToInt32(hs[A[i]]) + 1;
            return hs.Keys.OfType<int>().FirstOrDefault(x => hs[x].ToString() == "1");
        }
        public int[] ShiftZeroes(int[] A)
        {
            // Input = {1,0,0,5,2,0}
            // Output = {1,5,2,0,0,0}
            int left = 0;
            int right = A.Length - 1;
            while (left < right)
            {
                if (A[left] == 0)
                {
                    if (A[right] != 0)
                    {
                        A[left] = A[right];
                        A[right] = 0;
                        left++;
                        right--;
                    }
                    else
                        right--;
                }
                else
                    left++;
            }
            return A;
        }
        public int[] RotateArrayXTimes(int x, int[] A)
        {
            x = A.Length % x;
            int[] B = new int[A.Length];
            for (int i = 0; i < x; i++)
            {
                B[i] = A[A.Length - x + i];
            }
            for (int i = x; i < A.Length; i++)
            {
                B[i] = A[i - x];
            }
            return B;
        }
        public void RotateArrayLeft(int x, int[] A)
        {
            int[] B = new int[A.Length];
            x = A.Length - x;
            for (int i = 0; i < x; i++)
            {
                B[i] = A[A.Length - x + i];
            }
            for (int i = x; i < A.Length; i++)
            {
                B[i] = A[i - x];
            }
            for (int i = 0; i < B.Length; i++)
            {
                Console.Write(B[i] + " ");
            }
        }
        public int FindFibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            else
                return FindFibonacci(n - 1) + FindFibonacci(n - 2);
        }
        public int OptimizedFibonacci(int n)
        {
            int[] allFib = new int[50];
            allFib[0] = 1; allFib[1] = 1;
            return fib(n, allFib);
        }
        private int fib(int n, int[] allFib)
        {
            if (allFib[n] != 0) return allFib[n];
            else
            {
                allFib[n] = fib(n - 1, allFib) + fib(n - 2, allFib);
                return allFib[n];
            }
        }
        public void PrintFizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0) Console.WriteLine("FizzBuzz");
                else
                if (i % 5 == 0) Console.WriteLine("Buzz");
                else
                 if (i % 3 == 0) Console.WriteLine("Fizz");
                else
                    Console.WriteLine(i.ToString());
            }
        }
        public List<int> MergeArrays(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            int counterA = 0;
            int counterB = 0;

            while (counterA < a.Count && counterB < b.Count)
            {
                if (a[counterA] < b[counterB])
                {
                    result.Add(a[counterA]);
                    counterA++;
                }
                else
                {
                    result.Add(b[counterB]);
                    counterB++;
                }
            }
            while (counterA < a.Count)
            {
                result.Add(a[counterA]);
                counterA++;
            }
            while (counterB < b.Count)
            {
                result.Add(b[counterB]);
                counterB++;
            }

            return result;
        }


        public char getFirstUniqueCharacter(String phrase)
        {
            char[] A = phrase.ToCharArray();
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (frequencyMap.ContainsKey(A[i]))
                    frequencyMap[A[i]] += 1;
                else
                    frequencyMap[A[i]] = 1;
            }
            return frequencyMap.FirstOrDefault(x => x.Value == 1).Key;
        }
    }
}
