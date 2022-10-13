using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadSums
{
    internal class Sums
    {
        int[] op1, op2, res;
        Random rand = new Random();
        int offset, endArr, threadsExit = 0, threadCount;
        Thread t;

        public Sums(int nThreads, int nSums)
        {
            threadCount = nThreads;
            op1 = new int[nSums];
            op2 = new int[nSums];
            res = new int[nSums];
            
            for(int i = 0; i < nSums; i++)
            {
                op1[i] = rand.Next(1, nSums);
                op2[i] = rand.Next(1, nSums);
            }

            offset = (int)Math.Ceiling((decimal)nSums/(decimal)nThreads);
            endArr = nSums-1;

            for(int i = 0; i < nThreads; i++)
            {
                t = new Thread(add);
                t.Start(i);
            }
        }

        private int min(int a, int b)
        {
            if (a < b)
                return a;
            return b;
        }

        private void add(Object o)
        {
            int id = (int)o;

            int last = min((id+1) * offset - 1, endArr); //Evitando Excepciones

            for (int i = id * offset; i <= last; i++)
            {
                res[i] = op1[i] + op2[i];
            }
            threadsExit++;
        }

        public bool checkExit()
        {
            return threadsExit < threadCount;
        }
    }
}
