using System.Collections.Generic;

namespace RandomCSharpStuff
{
    public class GraphNode
    {
        public GraphNode ParentNode;
        public List<GraphNode> ChildrenNodes = new List<GraphNode>();
        public int Data;
        public bool Discovered = false;

        public GraphNode(int data)
        {
            Data = data;
        }
    }
}