using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCourseApp
{
    public class Program2
    {
        static void Main2(string[] args)
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();

            //var setsNum = int.Parse(args[0]);
            var setsNum = int.Parse(Console.ReadLine());

            int lineCount = 1;
            for (int r = 0; r < setsNum; r++)
            {
                //var counter = int.Parse(args[lineCount++]);
                var counter = int.Parse(Console.ReadLine());


                HashSet<RangeDate> ranges = new HashSet<RangeDate>();
                bool flag = false;
                for (int i = 0; i < counter; i++)
                {
                    var commonArr = Console.ReadLine().Split('-');
                    //string[] commonArr = args[lineCount++].Split('-');
                    if (flag) continue;

                    var start = commonArr[0].Split(':').Select(x => int.Parse(x)).ToArray();
                    var end = commonArr[1].Split(':').Select(x => int.Parse(x)).ToArray();

                    try
                    {
                        var startDate = new DateTime(2020, 1, 1, start[0], start[1], start[2]).Ticks;
                        var endDate = new DateTime(2020, 1, 1, end[0], end[1], end[2]).Ticks;

                        if ((endDate - startDate) < 0)
                        {
                            flag = true;
                            continue;
                        }

                        if ((ranges.Count == 0) || ranges.All(x => !RangeDate.IsInRange(x.Start, x.End, startDate) && !RangeDate.IsInRange(x.Start, x.End, endDate)
                            && !RangeDate.IsInRange(startDate, endDate, x.Start) && !RangeDate.IsInRange(startDate, endDate, x.End)))
                        {
                            ranges.Add(new RangeDate { Start = startDate, End = endDate });
                        }
                        else
                        {
                            flag = true;
                            continue;
                        }
                    }
                    catch
                    {
                        flag = true;
                        continue;
                    }

                }
                flag = false;

                if (ranges.Count == counter)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }


            }

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);









        }

    }

}
