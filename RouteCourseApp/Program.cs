using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
                var countDevelopers = int.Parse(Console.ReadLine());
                var arrLevel = Console.ReadLine().Split().Select((x, i) => new Level { Index = i, Value = int.Parse(x) });
                for (int j = 0; j < countDevelopers / 2; j++)
                {
                    var current = arrLevel.First();
                    var currentArr = arrLevel.Where(x => x.Index != current.Index).ToList();

                    var min = currentArr.Select(x => (int)Math.Abs(current.Value - x.Value)).OrderBy(x => x).First();
                    var next = currentArr.First(x => x.Value == (current.Value + min) || x.Value == (current.Value - min));

                    Console.WriteLine($"{current.Index + 1} {next.Index + 1}");
                    arrLevel = arrLevel.Where(x => x.Index != current.Index && x.Index != next.Index).ToList();
                }
                Console.WriteLine();
            }
        }
    }

    class Level
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }

    class LevelComparer : EqualityComparer<Level>
    {
        public override bool Equals(Level x, Level y)
        {
            return x.Value.Equals(y.Value);
        }

        public override int GetHashCode([DisallowNull] Level obj)
        {
            string value = obj.Value.ToString();
            return value.GetHashCode();
        }
    }
}
