using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{

    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int v)
        {
            Data = v;
        }
    }

    class TreeProblems
    {
        private int _maxDepth;

        public void Clear()
        {
            _maxDepth = 0;
        }

        public void PrintLeftView(Node node , int currentDepth =1)
        {
            if (node == null)
                return;
            if (currentDepth > _maxDepth)
            {
                Console.WriteLine(node.Data);
                _maxDepth = currentDepth;
            }
            PrintLeftView(node.Left, currentDepth+1);
            PrintLeftView(node.Right, currentDepth+1);
        }
        
    }
}
