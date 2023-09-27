
using System.Collections.Generic;

int[] list = { 300, 11, 53, 144, 74, 1, 27, 9, 220, 86, 13, 75, 23, 73, 84, 16, 36, 86, 82, 400, 73 };
Console.WriteLine("Max Value in the pocket: " + Findmax(list, 0, list.Length - 1));


static int Findmax(int[] list, int BeginningOfList, int endOfList)
{
    if (BeginningOfList == endOfList) /* if there is only one element in List*/
        return list[BeginningOfList];
    int middleOfList = (BeginningOfList + endOfList) / 2;

    return Math.Max(Findmax(list, BeginningOfList, middleOfList), Findmax(list, middleOfList + 1, endOfList));
}