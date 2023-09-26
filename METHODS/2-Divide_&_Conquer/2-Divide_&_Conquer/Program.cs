
using System.Collections.Generic;
int[] list = { 5, 11, 53, 74, 1, 27, 9, 22, 86, 13, 75, 23, 73, 84, 16, 36, 86, 82, 15, 73 };
int lengthOfList = list.Length;

Console.WriteLine("Max Value: " + findmax(list, lengthOfList));


static int findmax(int[] list, int lengthOfList)
{
    if (lengthOfList == 1)
    {
        return list[0];
        return Math.Max(list[list.Length - 1], lengthOfList);
    }
    return list[0];
/* thats the recursion? ithink*/
}