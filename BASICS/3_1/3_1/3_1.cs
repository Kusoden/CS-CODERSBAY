for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
        Console.WriteLine("FizzBuzz" + (i) + "!");

    else if (i % 3 == 0)
        Console.WriteLine("Fizz" + (i) + "!");

    else if (i % 5 == 0)
        Console.WriteLine("Buzz" + (i) + "!");
    else
        Console.WriteLine(i);
}