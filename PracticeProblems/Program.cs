using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(RainWaterCollection(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));

            var node =new Node(12);
            node.Left = new Node(10);
            node.Right = new Node(30);
            node.Right.Left = new Node(25);
            node.Right.Right = new Node(67);
            new TreeProblems().PrintLeftView(node);
            Console.ReadKey();
        }


        public static int RainWaterCollection(int[] elevation)
        {
            if (elevation.Length < 3)
                return 0;
            var n = elevation.Length;
            var right = new int[elevation.Length];
            var left = new int[elevation.Length];
            right[n - 1] = elevation[n - 1];
            left[0] = elevation[0];
            for (var i = 1; i < n; i++)
            {
                left[i] = elevation[i] > left[i - 1] ? elevation[i] : left[i - 1];
            }

            for (var j = n - 2; j >= 0; j--)
            {
                right[j] = elevation[j] > right[j + 1] ? elevation[j] : right[j + 1];
            }

            var collection = 0;
            for (var k = 1; k < n - 1; k++)
                collection += (left[k] < right[k] ? left[k] : right[k]) - elevation[k];
            return collection;
        }
    }
}
