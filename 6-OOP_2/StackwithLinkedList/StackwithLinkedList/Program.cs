namespace StackwithLinkedList;

class Program
{

    static void Main()
    {
        Stack obj = new();

        obj.Push("Destiny");
        obj.Push("Warcraft 3");
        obj.Push("League of Legends");
        obj.Push("Forza Horizon");
        obj.Push("Final Fantasy XV");
        obj.Push("Assassin's Creed");
        obj.Push("Baldur's Gate");
        obj.Push("Victoria 3");

        Console.WriteLine("size of the Library");

        Console.WriteLine(obj.Size()+"\n");
        

        obj.Display();

        Console.WriteLine("\nGame at the top: {0}\n", obj.Peek());

        obj.Pop();
        obj.Pop();

        Console.WriteLine("\nafter 2 popings Library:");
        obj.Display();

        Console.WriteLine("\nGame at the top: {0}\n", obj.Peek());

        Console.WriteLine("size of the Library");

        Console.WriteLine(obj.Size() + "\n");

        string[] poppedGames = obj.Pop(2);
        Console.WriteLine("PoppedGames: ");

        foreach(var game in poppedGames) Console.WriteLine(game);
    }
}