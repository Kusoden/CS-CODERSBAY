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

    public bool Doubly_Add(T value)
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
            tail.Next = newNode;
            tail = newNode;
        }

        size++;
        return true;
    }

    public void Doubly_Add(int index, T value)
    {
        DoublyNode<T>? newNode = new(value);

        if (index == 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        else if (index == size)
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
        else
        {
            DoublyNode<T>? current = Doubly_Get(index);
            DoublyNode<T>? previous = current.Previous;

            previous.Next = newNode;
            newNode.Previous = previous;
            newNode.Next = current;
            current.Previous = newNode;
        }

        size++;
    }

    public int Doubly_Size()
    {
        return size;
    }

    public T Doubly_Remove(int index)
    {
        DoublyNode<T> nodeToRemove = Doubly_Get(index);

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

    public DoublyNode<T> Doubly_Get(int index)
    {
        DoublyNode<T>? current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        return current;
    }

    public string Doubly_ToString()
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

    public string Doubly_ToStringReverse()
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