using System;
using System.Collections.Generic;

namespace RandomCSharpStuff
{
    public class Sorter
    {
        private List<int> Merge(List<int> list1, List<int> list2)
        {
            List<int> list3 = new List<int>();
            while (list1.Count > 0 && list2.Count > 0)
            {
                if (list1[0] > list2[0])
                {
                    list3.Add(list2[0]);
                    list2.RemoveAt(0);
                }
                else
                {
                    list3.Add(list1[0]);
                    list1.RemoveAt(0);
                }
            }
            while (list1.Count > 0)
            {
                list3.Add(list1[0]);
                list1.RemoveAt(0);
            }
            while (list2.Count > 0)
            {
                list3.Add(list2[0]);
                list2.RemoveAt(0);
            }
            return list3;
        } 

        public List<int> MergeSort(List<int> inputList)
        {
            if (inputList.Count == 1)
            {
                return inputList;
            }
            var list1 = inputList.GetRange(0, inputList.Count/2);
            var list2 = inputList.GetRange(inputList.Count/2, inputList.Count - inputList.Count/2);

            // recursively split lists until all sublists are of length 1
            list1 = MergeSort(list1);
            list2 = MergeSort(list2);
            
            return Merge(list1, list2);
        }

        public void QuickSort(List<int> inputList, int lo, int hi)
        {
            if (lo < hi)
            {
                var p = Partition(inputList, lo, hi);
                QuickSort(inputList, lo, p - 1);
                QuickSort(inputList, p + 1, hi);
            }
        }

        private int Partition(List<int> inputList, int lo, int hi)
        {
            Random random = new Random(); 
            var pivotIndex = random.Next(lo, hi + 1);
            Swap(inputList, pivotIndex, hi);
            int pivotValue = inputList[hi];  
            int i = lo;

            for (int j = lo; j < hi; j++)
            {
                if (inputList[j] <= pivotValue)
                {
                    Swap(inputList, i, j);
                    i++;
                }
            }

            Swap(inputList, i, hi);
            return i;
        }

        private void Swap(List<int> inputList, int i, int j)
        {
            var temp1 = inputList[i];
            var temp2 = inputList[j];
            inputList[j] = temp1;
            inputList[i] = temp2;
        }
    }
}