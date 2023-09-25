int[] list = { 5, 3, 4, 7, 1, 2, 1 };

for (int i = 1; i < list.Length; i++)
{
    int temp = list[i];
    int j = i - 1;

    while (j >= 0 && list[j] > temp)
    {
        list[j + 1] = list[j];
        j--;
    }

    list[j + 1] = temp;
}

for (int a = 0; a < list.Length; a++)
    Console.Write(list[a] + ",");
