using System;

namespace RandomCSharpStuff
{
    public class BinarySearchTree
    {
        public BstLeaf Root;

        public void Insert(BstLeaf root, int key)
        {
            if (key < root.Key)
            {
                if (root.Left == null)
                {
                    root.Left = new BstLeaf(key);
                }

                else
                {
                    root = root.Left;
                    Insert(root, key);

                }
            }
            else if (key > root.Key)
            {
                if (root.Right == null)
                {
                    root.Right = new BstLeaf(key);
                }

                else
                {
                    root = root.Right;
                    Insert(root, key);
                }
            }
        }

        public void Traverse(BstLeaf root)
        {
            if (root == null)
            {
                return;
            }
            
            Console.WriteLine(root.Key);
            Traverse(root.Right);
            Traverse(root.Left);
        }
    }
}