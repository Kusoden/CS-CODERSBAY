int[,] bingoBoard = new int[5, 5];
Random random = new();

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        int temp;

        do
        {
            temp = random.Next(1, 16);
            temp += i * 15;
        } while (temp == bingoBoard[0, i] || temp == bingoBoard[1, i] || temp == bingoBoard[2, i] || temp == bingoBoard[3, i]);
        bingoBoard[j, i] = temp;
    }
}

Console.WriteLine("  B   I   N   G   O");

for (int y = 0; y < 5; y++)
{
    for (int x = 0; x < 5; x++)
    {
        if (x == 2 && y == 2)
        {
            Console.Write("[GG!]");
        }
        else
        {
            Console.Write($"[{bingoBoard[y, x],2}]");
        }
    }
    Console.WriteLine();
}
