using System.Collections.Generic;

namespace RandomCSharpStuff
{
    public class BstLeaf
    {
        public int Key;
        public BstLeaf Parent;
        public BstLeaf Left;
        public BstLeaf Right;

        public BstLeaf(){}

        public BstLeaf(int key)
        {
            Key = key;
        }
    }
}