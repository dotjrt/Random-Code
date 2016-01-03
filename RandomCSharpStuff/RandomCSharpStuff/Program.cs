using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCSharpStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> intList = new List<int>(){3,4,5,1,2};
            Console.WriteLine("Min value in list: " + FindMin(intList));
            var sorter = new Sorter();
            var sortedList = sorter.MergeSort(intList);
            foreach (var n in sortedList)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
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
    }
}
