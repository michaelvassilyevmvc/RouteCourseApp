using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouteCourseApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var setsNum = int.Parse(Console.ReadLine());

            for (int r = 0; r < setsNum; r++)
            {
                var itemCount = int.Parse(Console.ReadLine());
                var sourceArr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                Dictionary<int, int> dict = new Dictionary<int, int>();
                bool hasMistake = false;

                for (int i = 0; i < itemCount; i++)
                {
                    if (!dict.ContainsKey(sourceArr[i]) )
                    {
                        dict.Add(sourceArr[i], i);
                    }
                    else if (i - dict[sourceArr[i]] == 1)
                    {
                        dict[sourceArr[i]] = i;
                    }
                    else
                    {
                        hasMistake = true;
                        break;
                    }

                }
                
                Console.WriteLine(GetAnswer(hasMistake));
                
            }
        }

        public static string GetAnswer(bool flag) => flag ? "NO" : "YES";

        
    }

   


}
