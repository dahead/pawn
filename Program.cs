using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace pawn
{
    class Program
    {

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) 
                return;
            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPermutations(char[] list)
        {
            int x = list.Length - 1;
            GetPermutations(list, 0, x);
        }

        private static void GetPermutations(char[] list, int recursionDepth, int maxDepth)
        {
            if (recursionDepth == maxDepth)
            {
                Console.WriteLine(list);
            }
            else
                for (int i = recursionDepth; i <= maxDepth; i++)
                {
                    Swap(ref list[recursionDepth], ref list[i]);
                    GetPermutations(list, recursionDepth + 1, maxDepth);
                    Swap(ref list[recursionDepth], ref list[i]);
                }
        }

        

        static void Main(string[] args)
        {
            string permutationtext = string.Empty;

            if (args.Length == 0)
                permutationtext = "123456789";
            else
                permutationtext = args[0];

            Stopwatch sw = new Stopwatch();
            sw.Start();

            GetPermutations(permutationtext.ToCharArray());
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Run time: " + elapsedTime);
        }
    }
}
