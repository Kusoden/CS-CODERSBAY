int[] list = { 5, 3, 4, 7, 1, 2, 1 };

for (int i = 0; i < list.Length - 1; i++)
{
    int cont = i;
    for (int j = i + 1; j < list.Length; j++)
        if (list[j] < list[cont])
            cont = j;

    (list[i], list[cont]) = (list[cont], list[i]); /*TUPLE*/
    /*  int temp = list[cont];
        list[cont] = list[i];
        list[i] = temp;*/
}

for (int a = 0; a < list.Length; a++)
    Console.Write(list[a] + " ");
