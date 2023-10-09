using System.Text;

namespace QueueDoubleLinkedList;
public class QueueLL
{
    private class QueueNode
    {
        public int Value;
        public QueueNode? Next;
        public QueueNode? Previous;

        public QueueNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    private QueueNode? head, tail;
    private int size;

    public void Enqueue(int newElement)
    {
        QueueNode? newNode = new(newElement);
        if (size == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        size++;
    }

    public int Size()
    {
        return size;
    }

    public int Dequeue()
    {
        if (size == 0)
            throw new NullReferenceException("The Queue is ALREADY empty!");
        else
        {
            int queueElement = head.Value;
            head = head.Next;

            if (head != null)
                head.Previous = null;
            else
                tail = null;
            size--;

            Console.WriteLine(queueElement);
            return queueElement;
        }
    }

    public int[] Dequeue(int n)
    {
        if (n > size)
            throw new IndexOutOfRangeException("Index is out of range!");
        else
        {
            int[] queuedElements = new int[Math.Min(n, size)];
            for (int i = 0; i < queuedElements.Length; i++)
                queuedElements[i] = Dequeue();
            return queuedElements;
        }
    }

    public override string ToString()
    {
        if (head == null)
            return "";

        QueueNode? temp = head;
        StringBuilder stringBuilder = new();

        while (temp != null)
        {
            stringBuilder.Append(temp.Value);
            stringBuilder.Append('|');
            temp = temp.Next;
        }

        return stringBuilder.ToString();
    }
}






