using System;
using System.Linq;
using System.Text;

namespace RouteCourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var setsNum = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int r = 0; r < setsNum; r++)
            {
                var rowAndCol = Console.ReadLine().Split();
                int row = int.Parse(rowAndCol[0]);
                int col = int.Parse(rowAndCol[1]);
                int[,] arr = new int[row, col];

                for (int i = 0; i < row; i++)
                {
                    var rowStr = Console.ReadLine().Split();
                    for (int j = 0; j < rowStr.Length; j++)
                    {
                        arr[i, j] = int.Parse(rowStr[j]);
                    }
                }

                int clicksCount = int.Parse(Console.ReadLine());
                var clickOrderArr = Console.ReadLine().NoRepeat().Split().Select(x => int.Parse(x) - 1).ToArray();



                Console.WriteLine();
                for (int s = 0; s < clickOrderArr.Count(); s++)
                {
                    arr = SortTable(arr, clickOrderArr[s]);
                }

                ShowTable(arr);
                Console.WriteLine();
            }
        }


        private static int[,] SortTable(int[,] arr, int col)
        {
            int[,] resArr = new int[arr.GetLength(0), arr.GetLength(1)];

            var needSortCol = CustomArray<int>.GetColumn(arr, col).Select((x, i) => new { Index = i, Value = x }).OrderBy(x => x.Value).ToArray();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    resArr[i, j] = arr[needSortCol[i].Index, j];
                }
            }
            return resArr;
        }

        private static void ShowTable(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public static class MyExtensions
    {
        public static string NoRepeat(this string value)
        {
            StringBuilder res = new StringBuilder();
            foreach (char c in value)
            {
                if (res.Length == 0 || !res[res.Length - 1].Equals(c))
                {
                    res.Append(c);
                }
            }
            return res.ToString();
        }
    }

    public static class CustomArray<T>
    {
        public static T[] GetColumn(T[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static T[] GetRow(T[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

    }


}
