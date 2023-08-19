using System;
using System.Linq;

namespace RouteCourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var setsNumb = int.Parse(Console.ReadLine());
            for (int i = 0; i < setsNumb; i++)
            {
                var arrNumb = int.Parse(Console.ReadLine());
                string source = Console.ReadLine();
                var productSum = (from price in source.Split(' ')
                                  group price by price into g
                                  select int.Parse(g.Key) * (g.Count() - (g.Count() / 3))).Sum();
                Console.WriteLine(productSum);
            }
        }
    }
}
