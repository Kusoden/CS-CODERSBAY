using System;
using static System.Net.Mime.MediaTypeNames;

Random r = new();

int[,] field = new int[10, 10];

for (int v = 0; v < field.GetLength(0); v++)
    for (int h = 0; h < field.GetLength(1); h++)
        field[v, h] = r.Next(2);        /*Initialize each region with a random status (0 or 1)*/

bool isDone = false;
do
{
    PrintField(field);
    int[,] nextField = NextGeneration(field);
    if (ArrayCompare(field, nextField))
        isDone = true;

    field = nextField;              /*Update the current region with the next generation region for printing*/
} while (!isDone);

void PrintField(int[,] field)/*Print the current status of the field*/
{
    Thread.Sleep(200);
    Console.Clear();
    Console.WriteLine("Next Generation:");
    for (int v = 0; v < field.GetLength(0); v++)
    {
        for (int h = 0; h < field.GetLength(1); h++)
        {
            if (field[v, h] == 0)               /*if 0 it will be dead*/
                Console.Write("  ");
            else
                Console.Write(" # ");
        }
        Console.WriteLine();
    }
}


int[,] NextGeneration(int[,] field)/*Create the next generation of regions*/
{
    int[,] nextField = new int[field.GetLength(0), field.GetLength(1)];

    for (int v = 0; v < field.GetLength(0); v++)
        for (int h = 0; h < field.GetLength(1); h++)
        {
            int aliveNeighbours = CountNeighbours(field, v, h);             /*Count alive neighbors*/

            if (aliveNeighbours == 3)
                nextField[v, h] = 1;                /*region is born*/
            else if (aliveNeighbours == 2)
                nextField[v, h] = field[v, h];          /*region stays the same*/
            else
                nextField[v, h] = 0;            /*region dies*/
        }
    return nextField;
}



int CountNeighbours(int[,] field, int row, int col)/*count the number of alive neighbors for a given region*/
{
    int aliveNeighbours = -field[row, col];

    for (int v = -1; v <= 1; v++)
        for (int h = -1; h <= 1; h++)
        {
            int newRow = row + v;
            int newCol = col + h;
            if (!(newRow < 0 || newRow >= field.GetLength(0) || newCol < 0 || newCol >= field.GetLength(1)))
                aliveNeighbours += field[newRow, newCol];               /*Add neighbor's value if within borders*/
        }
    return aliveNeighbours;
}


bool ArrayCompare(int[,] arr1, int[,] arr2)/*Check if both arrays have the same content*/
{
    for (int v = 0; v < arr1.GetLength(0); v++)
        for (int h = 0; h < arr1.GetLength(1); h++)
            if (arr1[v, h] != arr2[v, h])
                return false;
    return true;
}