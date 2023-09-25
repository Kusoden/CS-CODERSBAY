Console.WriteLine("Type in what hour it is right now (MINUTE NOT INCLUDED)");
int scHr = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Type in what minute it is right now");
int scMin = Convert.ToInt32(Console.ReadLine());

if (scHr == 12 && (scMin >= 30 && scMin <= 60))
    Console.WriteLine("LUNCH BREAK!");
else if ((scHr <= 8 && scMin < 30) || (scHr >= 15 && scMin > 30))
    Console.WriteLine("It is not work time");
else
    Console.WriteLine("It is work time");