int[] list = { 5, 3, 4, 7, 1, 2, 1 };

int cont = 0;
for (int i = 0; i < list.Length - 1; i++)
{
    for (int j = 1; j < list.Length - i; j++)
        if (list[j - 1] > list[j])
        {
            cont = list[j - 1];
            list[j - 1] = list[j];
            list[j] = cont;
        }
}

for (int a = 0; a < list.Length; a++)
    Console.Write(list[a] + " ");
