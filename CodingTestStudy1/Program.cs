using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTestStudy1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Week1

            //Week1 test = new Week1();

            //foreach (var item in test.solution(new string[] { "sun", "bed", "car" }, 1))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadLine();

            #endregion

            #region Week2

            Week2 test = new Week2();

            Console.WriteLine(test.solution(new int[] { 95, 90, 99, 99, 80, 99 }, new int[] { 1, 1, 1, 1, 1, 1 }));
            Console.ReadLine();

            #endregion
        }
    }
}
