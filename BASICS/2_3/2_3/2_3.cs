int sc;

do
{
    Console.WriteLine("What is your numerical grade? it should be between 1-5 (1 and 5 included)");
    sc = Convert.ToInt32(Console.ReadLine());
} while (sc < 1 || sc > 5);

if (sc == 1)
    Console.WriteLine("Very good");
else if (sc == 2)
    Console.WriteLine("Good");
else if (sc == 3)
    Console.WriteLine("Satisfactory");
else if (sc == 4)
    Console.WriteLine("Sufficient");
else if (sc == 5)
    Console.WriteLine("Not sufficient");