namespace StackwithLinkedList;

class Program
{

    static void Main()
    {
        Stack library = new();

        library.Push("Destiny");
        library.Push("Warcraft 3");
        library.Push("League of Legends");
        library.Push("Forza Horizon");
        library.Push("Final Fantasy XV");
        library.Push("Assassin's Creed");
        library.Push("Baldur's Gate");
        library.Push("Victoria 3");

        Console.WriteLine("size of the Library");

        Console.WriteLine(library.Size()+"\n");
        

        library.Display();

        Console.WriteLine("\nGame at the top: {0}\n", library.Peek());

        library.Pop();
        library.Pop();

        Console.WriteLine("\nafter 2 popings Library:");
        library.Display();

        Console.WriteLine("\nGame at the top: {0}\n", library.Peek());

        Console.WriteLine("size of the Library");

        Console.WriteLine(library.Size() + "\n");

        string[] poppedGames = library.Pop(2);
        Console.WriteLine("PoppedGames: ");

        foreach(var game in poppedGames) Console.WriteLine(game);
    }
}