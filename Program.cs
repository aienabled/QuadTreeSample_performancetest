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
        static void sanity_test1()
        {
            Vector2Int pos = new Vector2Int(1, 1);
            QuadTreeNode q = new QuadTreeNode(pos, 1);
            Debug.Assert(q.Size == 1);
            Debug.Assert(q.SubNodesCount == 0);
        }

        static void perf_test1()
        {
            Vector2Int pos = new Vector2Int(1, 1);
            QuadTreeNode q = new QuadTreeNode(pos, 1);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int j = 1;
            for( int i = 0; i < 100000; i++)
            {
                j += i + i;
            }

            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        static void Main(string[] args)
        {
            sanity_test1();
            perf_test1();

            Helpers.keepConsoleOpen();
        }
    }
}
