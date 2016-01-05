using System;
using System.Collections.Generic;

namespace RandomCSharpStuff
{
    public class Graph
    {
        public GraphNode Root = new GraphNode(0);
        public List<GraphNode> Nodes = new List<GraphNode>();

        public Graph(GraphNode root)
        {
            Root = root;
        }

        public void Print()
        {
            foreach (var node in Nodes)
            {
                Console.Write("{0} - ", node.Data);
                foreach (var child in node.ChildrenNodes)
                {
                    Console.Write(" {0} ", child.Data);
                }
                Console.WriteLine();
            }
        }

        public void BreadthFirstSearch()
        {
            Console.Write("BFS ordering: ");
            Queue<GraphNode> queue = new Queue<GraphNode>();

            Console.Write(Root.Data + " ");
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                foreach (var node in current.ChildrenNodes)
                {
                    if (!node.Discovered)
                    {
                        Console.Write(node.Data + " ");
                        node.Discovered = true;
                        queue.Enqueue(node);
                    }
                }
            }
            Console.WriteLine();
        }

        public void DepthFirstSearch()
        {
            Console.Write("DFS ordering: ");
            Stack<GraphNode> stack = new Stack<GraphNode>();
            stack.Push(Root);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                if (!current.Discovered)
                {
                    Console.Write(current.Data + " ");
                    current.Discovered = true;

                    foreach (var node in current.ChildrenNodes)
                    {
                        stack.Push(node);
                    }
                }
            }
            Console.WriteLine();
        }

        public void DfsRecursive(GraphNode node)
        {
            node.Discovered = true;
            Console.Write(node.Data + " ");
            foreach (var n in node.ChildrenNodes)
            {
                if (!n.Discovered)
                {
                    DfsRecursive(n);
                }
            }
        }
    }
}