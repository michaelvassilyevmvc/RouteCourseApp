using System;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 4, 5, 5, 5, 6 };
            Console.WriteLine(FindIndexByBinarySearch(array, 5));
        }

        static int FindIndexByBinarySearch(int[] array, int element)
        {
            int left = 0;
            int right = array.Length - 1;   
            while(left < right)
            {
                var middle = (right + left) / 2;
                if (array[middle] < element)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }

            }

            if (array[left] != element) return -1;
            return left;
        }

    }
}
