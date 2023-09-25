int luckyNumber = 7;

Console.WriteLine("lucky number is: " + luckyNumber);
Console.WriteLine("Input a number");

int sc = Convert.ToInt32(Console.ReadLine());

if (sc % 2 == 0)
{
    Console.WriteLine("writen number '" + sc + "' is an even number");
}
else
{
    Console.WriteLine("written number '" + sc + "' is an odd number");
}

if (sc == luckyNumber)
{
    Console.WriteLine("written number '" + sc + "' is the lucky number");
}

Console.WriteLine("Number length is " + sc.ToString().Length);