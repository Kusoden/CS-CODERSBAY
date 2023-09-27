int[] list = { 300, 11, 53, 144, 74, 1, 27, 9, 220, 86, 13, 75, 23, 73, 84, 16, 36, 86, 82, 400, 73 };
Console.WriteLine("Original List: ");
Write(list);

static void Write(int[] list)
{
    foreach (int element in list) Console.Write(element.ToString() + " ");
}


