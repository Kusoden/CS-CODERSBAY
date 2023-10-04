
using System;
using System.Text;

namespace _2_Linked_List;
public class LinkedList<T>
{
    private Node<T>? head;
    private int size;

    public LinkedList()
    {
        head = null;
        size = 0;
    }

    public bool Add(T value)
    {
        if(value == null) {
            Console.WriteLine("You know... this value is null ... so " +
                "I won't add this ...");
            return false;
        }

        Node<T> newNode = new(value);

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
        Node<T> newNode = new(value);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node<T>? previous = null;
            Node<T>? current = head;
            int currentIndex = 0;

            while (currentIndex < index && current != null)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }
            if (previous == null)
                throw new InvalidOperationException("Previous or current node is null.");
            else
            {
                previous.Next = newNode;
                newNode.Next = current;
            }
        }
        size++;
    }

    public int Size()
    {
        return size;
    }

    public T GetValue(int index)
    {
        if (index >= 0 && index <= size)
        {
            Node<T>? current = head;
            int currentIndex = 0;

            while (currentIndex < index && current != null)
            {
                current = current.Next;
                currentIndex++;
            }
            if (current == null)
                throw new InvalidOperationException("node is null and it shouldnt be...");
            return current.Value;
        }
        if (head == null)
            throw new InvalidOperationException("this list is empty...");
        return head.Value; 
            
            
    }

    public T Remove(int index)
    {
        if (index == 0 && head != null)
        {
            T removedValue = head.Value;
            head = head.Next;
            size--;
            return removedValue;
        }
        else
        {
            Node<T>? current = head;
            int currentIndex = 0;

            while (currentIndex < index && current != null)
            {
                current = current.Next;
                currentIndex++;
            }

            size--;
            if (current == null)
                throw new InvalidOperationException("Current node is null and it shouldnt be...");
            return current.Value;
        }
    }

    public override string ToString()
    {
        if (size == 0)
            return "none, it's empty";
        if (head == null)
            throw new InvalidOperationException("node is null and it shouldnt be...");
        Node<T>? current = head;
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
