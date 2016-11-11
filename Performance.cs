using QuadTreeSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//using QuadTreeNode;

namespace QuadTreeSample
{
    public static class Helpers
    {
        public static void keepConsoleOpen()
        {
            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class Program
    {
        //Note to self - the position is the top-left corner of the Q-T
        //It's not the center.
        static void sanity_test1()
        {
            Vector2Int pos = new Vector2Int(0, 0);
            QuadTreeNode q = new QuadTreeNode(pos, 1);
            Debug.Assert(q.Size == 1);
            Debug.Assert(q.SubNodesCount == 0);
        }

        static void perf_test1()
        {
            const int MAX_SIZE = 1 << 14;
            const int R_SEED = 1;
            const int ITERATIONS = 100000;
            const int RUNS = 7;

            Console.WriteLine("Performance Test 1");

            for (int run = 0; run < RUNS; run++)
            {
                Vector2Int pos = new Vector2Int(0, 0);
                QuadTreeNode q = new QuadTreeNode(pos, MAX_SIZE);
                Random r = new Random(R_SEED);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i < ITERATIONS; i++)
                {
                    Vector2Int point = new Vector2Int(r.Next(0, MAX_SIZE - 1), r.Next(0, MAX_SIZE - 1));
                    q.SetFilledPosition(point);
                }

                sw.Stop();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);

                Console.WriteLine("{0} filled", q.FilledRatio);
            }
        }

        static void perf_test2()
        {
            const int MAX_SIZE = 1 << 6;
            const int R_SEED = 1;
            const int ITERATIONS = 100000;
            const int RUNS = 7;

            Console.WriteLine("Performance Test 2");

            for (int run = 0; run < RUNS; run++)
            {
                Vector2Int pos = new Vector2Int(0, 0);
                QuadTreeNode q = new QuadTreeNode(pos, MAX_SIZE);
                Random r = new Random(R_SEED);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i < ITERATIONS; i++)
                {
                    Vector2Int point = new Vector2Int(r.Next(0, MAX_SIZE - 1), r.Next(0, MAX_SIZE - 1));
                    q.SetFilledPosition(point);
                }

                sw.Stop();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);

                Console.WriteLine("{0} filled", q.FilledRatio);
            }
        }

        static void perf_test3()
        {
            const int MAX_SIZE = 1 << 9;
            const int R_SEED = 1;
            const int ITERATIONS = 100000;
            const int RUNS = 7;

            Console.WriteLine("Performance Test 3");

            Vector2Int pos = new Vector2Int(0, 0);
            QuadTreeNode q = new QuadTreeNode(pos, MAX_SIZE);
            Random r = new Random(R_SEED);

            for (int i = 0; i < 100000; i++)
            {
                Vector2Int point = new Vector2Int(r.Next(0, MAX_SIZE - 1), r.Next(0, MAX_SIZE - 1));
                q.SetFilledPosition(point);
            }

            for (int run = 0; run < RUNS; run++)
            {
                Random j = new Random(R_SEED);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                int count = 0;
                for (int i = 0; i < ITERATIONS; i++)
                {
                    Vector2Int point = new Vector2Int(r.Next(0, MAX_SIZE - 1), r.Next(0, MAX_SIZE - 1));
                    bool z = q.IsPositionFilled(point);
                    if(z) { count++; }
                }

                sw.Stop();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);

                double ratio = (double)count / (double)ITERATIONS;
                Console.WriteLine("{0} filled, {1} hit ratio", q.FilledRatio, ratio);
            }
        }

        static void Main(string[] args)
        {
            sanity_test1();
            perf_test1();
            perf_test2();
            perf_test3();

            Helpers.keepConsoleOpen();
        }
    }
}
