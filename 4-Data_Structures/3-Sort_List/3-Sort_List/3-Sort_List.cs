using System;
using System.Collections.Generic;

namespace _3_Sort_List
{
    class Program
    {
        static void Main()
        {
            List<int> list = new() { 5, 3, 4, 7, 1, 2, 1 }; 

            Console.WriteLine("Original List: ");
            Write(list);

            MergeSort(list);
            Console.WriteLine("\nMergeSorted List: ");
            Write(list);
        }

        static void Write(List<int> list)
        {
            foreach (int element in list) Console.Write(element.ToString() + " ");
        }

        static void MergeSort(List<int> list)
        {
            int lengthOfList = list.Count; /* .Length => .Count */
            if (lengthOfList <= 1) return;

            int middle = lengthOfList / 2;
            List<int> leftList = list.GetRange(0, middle);/*new int [middle] => .getRange*/
            List<int> rightList = list.GetRange(middle, lengthOfList - middle); 

            MergeSort(leftList);
            MergeSort(rightList);
            Merge(leftList, rightList, list);
        }

        static void Merge(List<int> leftList, List<int> rightList, List<int> list)
        {
            int leftSize = leftList.Count;
            int rightSize = rightList.Count;
            int originalListIndex = 0, leftListIndex = 0, rightListIndex = 0;

            while (leftListIndex < leftSize && rightListIndex < rightSize)
            {
                if (leftList[leftListIndex] < rightList[rightListIndex])
                {
                    list[originalListIndex] = leftList[leftListIndex];
                    leftListIndex++;
                }
                else
                {
                    list[originalListIndex] = rightList[rightListIndex];
                    rightListIndex++;
                }
                originalListIndex++;
            }

            while (leftListIndex < leftSize)
            {
                list[originalListIndex] = leftList[leftListIndex];
                originalListIndex++;
                leftListIndex++;
            }

            while (rightListIndex < rightSize)
            {
                list[originalListIndex] = rightList[rightListIndex];
                originalListIndex++;
                rightListIndex++;
            }
        }
    }
}