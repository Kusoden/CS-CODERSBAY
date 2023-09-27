int[] list = { 300, 11, 53, 144, 74, 1, 27, 9, 220, 86, 13, 75, 23, 73, 84, 16, 36, 86, 82, 400, 73 };
Console.WriteLine("Original List: ");
Write(list);

MergeSort(list);
Console.WriteLine("\nMergeSorted List: ");
Write(list);

static void Write(int[] list)
{
    foreach (int element in list) Console.Write(element.ToString() + " ");
}


static void MergeSort(int[] list)
{
    int lengthOfList = list.Length;
    if (lengthOfList == 1) return;

    int middle = lengthOfList / 2;
    int[] leftList = new int[middle]; /*Subarrays*/
    int[] rightList = new int[lengthOfList - middle];

    int leftStore = 0;
    int rightStore = 0;

    for (; leftStore < lengthOfList; leftStore++)
    {
        if (leftStore < middle)/*Fill subarrays*/
            leftList[leftStore] = list[leftStore];
        else
        {
            rightList[rightStore] = list[leftStore];
            rightStore++;
        }
    }
    MergeSort(leftList); /*recursion sort both sides*/
    MergeSort(rightList);
    Merge(leftList, rightList, list);/*Merge the sorted subarrays back into the original list*/
}

static void Merge(int[] leftList, int[] rightList, int[] list)
{
    int leftSize = leftList.Length;
    int rightSize = rightList.Length;
    int originalListIndex = 0, leftListIndex = 0, rightListIndex = 0;

    while (leftListIndex < leftSize && rightListIndex < rightSize)/*While elements exist in both left and right arrays, we keep adding them to the original array.*/
    {
        if (leftList[leftListIndex] < rightList[rightListIndex])/* compare left to right, take smaller*/
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
    while (leftListIndex < leftSize)/*Copy any remaining elements from subarrays*/
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