using System.Text;

namespace QueueDoubleLinkedList;
class Program
{
    static void Main()
    {
        QueueLL theQueue = new();

        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        theQueue.Enqueue(3);
        theQueue.Enqueue(4);
        theQueue.Enqueue(5);
        theQueue.Enqueue(6);
        theQueue.Enqueue(7);
        theQueue.Enqueue(8);
        theQueue.Enqueue(9);
        theQueue.Enqueue(10);

        Console.WriteLine(theQueue.ToString()+ "\n\n");
        Console.WriteLine("DEQUEUED NUMBER: " + theQueue.Dequeue());


        Console.WriteLine("\n\nAfter DEQUEUING:"+ theQueue.ToString());
        int[] Dequeue = theQueue.Dequeue(2);


        Console.WriteLine("Removed and stored numbers: ");
        foreach ( int numb in Dequeue ) Console.Write("|"+numb);

        Console.WriteLine("\n\nAfter DEQUEUING and STORING:" + theQueue.ToString());
    }
}