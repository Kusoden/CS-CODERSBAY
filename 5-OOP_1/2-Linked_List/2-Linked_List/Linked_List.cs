using _2_Linked_List;
using System;
using System.Text;

public class LinkedList<T>
{
    private Node<T> head;
    private int size;

    public LinkedList()
    {
        head = null;
        size = 0;
    }

    public bool Add(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (head == null)
            head = newNode;
        else
        {
            Node<T> current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }
        size++;
        return true;
    }

    public void Add(int index, T value)
    {
        if (index < 0 || index > size)
            throw new IndexOutOfRangeException("Index is out of range.");

        Node<T> newNode = new Node<T>(value);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node<T> previous = null;
            Node<T> current = head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            previous.Next = newNode;
            newNode.Next = current;
        }
        size++;
    }

    public int Size()
    {
        return size;
    }

    public T Get(int index)
    {
        Node<T> current = head;
        int currentIndex = 0;

        while (currentIndex < index)
        {
            current = current.Next;
            currentIndex++;
        }

        return current.Value;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= size)
            throw new IndexOutOfRangeException("Index is out of range.");

        if (index == 0)
        {
            T removedValue = head.Value;
            head = head.Next;
            size--;
            return removedValue;
        }
        else
        {
            Node<T> previous = null;
            Node<T> current = head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            previous.Next = current.Next;
            size--;
            return current.Value;
        }
    }

    public override string ToString()
    {
        if (size == 0)
            return "empty";

        Node<T> current = head;
        StringBuilder result = new();
        while (current != null)
        {
            result.Append(current.Value);
            if (current.Next != null)
                result.Append(", ");
            current = current.Next;
        }
        return result.ToString();
    }
}
