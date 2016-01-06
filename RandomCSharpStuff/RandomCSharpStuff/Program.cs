using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RandomCSharpStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> intList = new List<int>(){3,4,5,6,7,1,2};
            Console.WriteLine("Min value in list: " + FindMin(intList));
            var sorter = new Sorter();
            //var sortedList = sorter.MergeSort(intList);
            sorter.QuickSort(intList, 0, intList.Count - 1);
            var sortedList = intList;

            Console.Write("Sorted list: ");
            foreach (var n in sortedList)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // Test BFS and DFS of tree graph
            Graph g = InitializeGraph();
            g.Print();
            g.BreadthFirstSearch();
            foreach (var node in g.Nodes){ node.Discovered = false; } // reset Discovered property for each node
            g.DepthFirstSearch();
            foreach (var node in g.Nodes) { node.Discovered = false; }
            Console.Write("Recursive DFS ordering: ");
            g.DfsRecursive(g.Root);
            //

            Console.ReadKey();
        }

        private static Graph InitializeGraph()
        {
            var rootNode = new GraphNode(1);
            var two = new GraphNode(2);
            var seven = new GraphNode(7);
            var eight = new GraphNode(8);
            var three = new GraphNode(3);
            var six = new GraphNode(6);
            var nine = new GraphNode(9);
            var twelve = new GraphNode(12);
            var four = new GraphNode(4);
            var five = new GraphNode(5);
            var ten = new GraphNode(10);
            var eleven = new GraphNode(11);

            rootNode.ChildrenNodes.Add(two);
            rootNode.ChildrenNodes.Add(seven);
            rootNode.ChildrenNodes.Add(eight);

            two.ParentNode = rootNode;
            two.ChildrenNodes.Add(three);
            two.ChildrenNodes.Add(six);

            three.ParentNode = two;
            three.ChildrenNodes.Add(four);
            three.ChildrenNodes.Add(five);

            eight.ParentNode = rootNode;
            eight.ChildrenNodes.Add(nine);
            eight.ChildrenNodes.Add(twelve);

            nine.ParentNode = eight;
            nine.ChildrenNodes.Add(ten);
            nine.ChildrenNodes.Add(eleven);

            var graph1 = new Graph(rootNode);
            graph1.Nodes.Add(rootNode);
            graph1.Nodes.Add(two);
            graph1.Nodes.Add(three);
            graph1.Nodes.Add(four);
            graph1.Nodes.Add(five);
            graph1.Nodes.Add(six);
            graph1.Nodes.Add(seven);
            graph1.Nodes.Add(eight);
            graph1.Nodes.Add(nine);
            graph1.Nodes.Add(ten);
            graph1.Nodes.Add(eleven);
            graph1.Nodes.Add(twelve);
            return graph1;
        }

        // Find minimum value in list given that list was previously sorted and then rotated
        // (i.e. 1,2,3,4,5 is rotated to 3,4,5,1,2) and all values in list are unique integers
        // (uses binary search modification)
        public static int FindMin(List<int> inputList)
        {
            if (inputList.Count == 1)
            {
                return inputList[0];
            }
            else
            {
                int mid;
                int right = inputList[inputList.Count - 1];
                if (inputList.Count%2 == 0)
                {
                    mid = inputList[inputList.Count / 2 - 1];
                }
                else
                {
                    mid = inputList[inputList.Count / 2];
                }
                
                List<int> sublist = new List<int>();
                if (mid > right)
                {
                    sublist = inputList.GetRange(inputList.IndexOf(mid) + 1,
                        inputList.Count - 1 - inputList.IndexOf(mid));
                    return FindMin(sublist);
                }
                else
                {
                    sublist = inputList.GetRange(0, inputList.IndexOf(mid) + 1);
                    return FindMin(sublist);
                }
            }
        }

        // LYFT programming challenge:
        // Calculate the detour distance between two different rides. Given four latitude / longitude pairs, 
        // where driver one is traveling from point A to point B and driver two is traveling from point C 
        // to point D, write a function (in your language of choice) to calculate the shorter of the detour 
        // distances the drivers would need to take to pick-up and drop-off the other driver.

        // ***Calculations assume driving straight line distances between coordinates***
        // Driver 1 would drive from A to C (pick up driver 2) to D (drop off driver 2) and finally to B
        // Driver 2 would drive from C to A (pick up driver 1) to B (drop off driver 1) and finally to D
        // Both routes involve trips between A & C and B & D, so those distances need not be considered
        // when determining which driver would have the shorter overall detour route
        // This avoids calculating the distances for both the full routes, only the one that must be shorter
        // Therefore, if distance(A,B) > distance(C,D), driver 1 would have the shorter overall detour route
        // Otherwise, distance(C,D) > distance(A,B), so driver 2 would have the shorter overall detour route

        public double ShortestDetour(GeoCoordinate pointA, GeoCoordinate pointB, GeoCoordinate pointC,
            GeoCoordinate pointD)
        {
            if (pointA.GetDistanceTo(pointB) > pointC.GetDistanceTo(pointD))
            {
                // Driver 1 has the shorter route
                return pointA.GetDistanceTo(pointC) + pointC.GetDistanceTo(pointD) + pointD.GetDistanceTo(pointB);
            }
            // Driver 2 has the shorter route
            return pointC.GetDistanceTo(pointA) + pointA.GetDistanceTo(pointB) + pointB.GetDistanceTo(pointD);
        }
    }
}
