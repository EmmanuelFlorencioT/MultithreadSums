using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            
            for(int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    sw.Restart();
                    Sums s = new Sums(j, i*10000);
                    while (s.checkExit()) { }
                    sw.Stop();
                    Console.WriteLine("Threads = {0}, Sums = {1}, Time = {2}ms", j, i*10000, sw.ElapsedMilliseconds);
                }
                Console.WriteLine("----------------");
            }
        }
    }
}
