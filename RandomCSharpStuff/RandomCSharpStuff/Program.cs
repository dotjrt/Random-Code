using System;
using System.Collections.Generic;
using System.Device.Location;
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
            //var sortedList = sorter.MergeSort(intList);
            sorter.QuickSort(intList, 0, intList.Count - 1);
            var sortedList = intList;

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

        // LYFT programming challenge:
        // Calculate the detour distance between two different rides. Given four latitude / longitude pairs, 
        // where driver one is traveling from point A to point B and driver two is traveling from point C 
        // to point D, write a function (in your language of choice) to calculate the shorter of the detour 
        // distances the drivers would need to take to pick-up and drop-off the other driver.

        // ***Calculations assume driving straight line distances between coordinates***
        // Driver 1 would drive from A to C (pick up driver 2) to D (drop off driver 2) and finally to B
        // Driver 2 would drive from C to A (pick up driver 1) to B (drop off driver 1) and finally to D
        // Both routes involve trips between A & C and B & D, so those distances can be eliminated from consideration
        // Therefore, if distance(A,B) > distance(C,D), driver 1 would have the shorter overall detour route
        // Otherwise, distance(C,D) > distance(A,B), so driver 2 would have the shorter overall detour route
        public double ShortestDetour(GeoCoordinate pointA, GeoCoordinate pointB, GeoCoordinate pointC,
            GeoCoordinate pointD)
        {
            if (pointA.GetDistanceTo(pointB) > pointC.GetDistanceTo(pointD))
            {
                //Driver 1 has the shorter route
                return pointA.GetDistanceTo(pointC) + pointC.GetDistanceTo(pointD) + pointD.GetDistanceTo(pointB);
            }
            //Driver 2 has the shorter route
            return pointC.GetDistanceTo(pointA) + pointA.GetDistanceTo(pointB) + pointB.GetDistanceTo(pointD);
        }
    }
}
