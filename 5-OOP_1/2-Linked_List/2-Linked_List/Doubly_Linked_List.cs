using System;
using System.Text;

namespace _2_Linked_List;

public class Doubly_Linked_List<T>
{
    private DoublyNode<T>? head;
    private DoublyNode<T>? tail;
    private int size;

    public Doubly_Linked_List()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public bool Add(T value)
    {
        DoublyNode<T>? newNode = new(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            if (tail == null)
            {
                throw new ArgumentNullException(nameof(value)); //TODO
            }
            else 
            { 
            tail.Next = newNode;
            tail = newNode;
            }
        }

        size++;
        return true;
    }

    public void Add(int index, T value)
    {
        if (index < 0 || index > size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        DoublyNode<T>? newNode = new(value);

        if (index == 0)
        {
            if (head == null)
            {
                throw new InvalidOperationException("Head is null.");
            }

            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        else if (index == size)
        {
            if (tail == null)
            {
                throw new InvalidOperationException("Tail is null.");
            }

            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        else
        {
            DoublyNode<T>? current = Get(index);
            DoublyNode<T>? previous = current?.Previous;

            if (previous == null || current == null)
            {
                throw new InvalidOperationException("Previous or current node is null.");
            }

            previous.Next = newNode;
            newNode.Previous = previous;
            newNode.Next = current;
            current.Previous = newNode;
        }

        size++;
    }

    public int Size()
    {
        return size;
    }

    public T Remove(int index)
    {
        DoublyNode<T> nodeToRemove = Get(index);

        if (nodeToRemove.Previous != null)
            nodeToRemove.Previous.Next = nodeToRemove.Next;
        else
            head = nodeToRemove.Next;

        if (nodeToRemove.Next != null)
            nodeToRemove.Next.Previous = nodeToRemove.Previous;
        else
            tail = nodeToRemove.Previous;

        size--;
        return nodeToRemove.Value;
    }


    public DoublyNode<T> Get(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        if (index < size / 2) /*Start from the front*/
        {
            DoublyNode<T>? current = head;
            for (int i = 0; i < index; i++)
                current = current?.Next;

            if (current == null)
                throw new InvalidOperationException("Node is null.");
            return current;
        }
        else/*Start from the back*/
        {
            DoublyNode<T>? current = tail;
            for (int i = size - 1; i > index; i--)
                current = current?.Previous;

            if (current == null)
                throw new InvalidOperationException("Node is null.");
            return current;
        }
    }

    public override string ToString()
    {
        if (size == 0)
            return "none, it's empty";

        DoublyNode<T>? current = head;
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

    public string ToStringReverse()
    {
        if (size == 0)
            return "none, it's empty";

        DoublyNode<T>? current = tail;
        StringBuilder result = new();
        while (current != null)
        {
            result.Append(current.Value);
            if (current.Previous != null)
                result.Append(", ");
            current = current.Previous;
        }
        return result.ToString();
    }
}