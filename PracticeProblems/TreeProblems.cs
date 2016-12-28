using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeProblems
{

    class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public int Rank ;

        public Node(int v)
        {
            Data = v;
        }
    }

    class BST
    {
        private Node _root;

        public void Add(int[] input)
        {
            foreach (var i in input)
            {
                Add(new Node(i));
            }
        }

        public void Add(Node node)
        {
            if (_root == null)
            {
                _root = node;
                return;
            }

            var temp = _root;
            while (true)
            {
                if (node.Data < temp.Data)
                {
                    temp.Rank++;
                    if (temp.Left != null)
                    {
                        temp = temp.Left;
                    }
                    else
                    {
                        temp.Left = node;
                        break;
                    }

                }
                else
                    if (temp.Right != null)
                        temp = temp.Right;
                    else
                    {
                        temp.Right = node;
                        break;
                    }
            }
        }


        public void AddRec(ref Node node, Node newNode)
        {
            if (node == null)
            {
                node = newNode;
                return;
            }
            if (node.Data > newNode.Data)
                AddRec(ref node.Left, newNode);
            else
                AddRec(ref node.Right, newNode);
        }




        public void DoInorder(Action<Node> action)
        {
            var temp = _root;
            var stack = new Stack<Node>();
            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.Left;
            }

            while (stack.Any())
            {
                temp = stack.Pop();
                action(temp);
                temp = temp.Right;
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }
            }
        }

        public int KthSmallestElement(int k)
        {
            var stack = new Stack<Node>();

            var temp = _root;
            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.Left;
            }

            while (stack.Any())
            {
                temp = stack.Pop();
                if (--k == 0)
                    return temp.Data;
                else
                {
                    temp = temp.Right;
                    while (temp != null)
                    {
                        stack.Push(temp);
                        temp = temp.Left;
                    }
                }
            }

            return 0;
        }


        public int KthSmallestElemt(int k)
        {
            --k;
            var temp = _root;
            while (true)
            {
                if(k == temp.Rank)
                    return temp.Data;
                if (k < temp.Rank)
                    temp = temp.Left;
                else
                {
                    k -= (temp.Rank+1);
                    temp = temp.Right;
                }
            }
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
