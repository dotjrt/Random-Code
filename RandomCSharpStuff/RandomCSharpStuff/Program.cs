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
            List<int> intList = new List<int>(){3,4,5,6,7,1,2};
            Console.WriteLine(FindMin(intList));
            
            Console.ReadKey();
        }

        public static int FindMin(List<int> inputList)
        {
            if (inputList.Count == 1)
            {
                return inputList[0];
            }
            else
            {
                int mid = 0;
                int right = inputList[inputList.Count - 1];;
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
