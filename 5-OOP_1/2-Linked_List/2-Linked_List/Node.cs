using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Linked_List;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}
public class DoublyNode<T>
{
    public T Value { get; set; }
    public DoublyNode<T>? Previous { get; set; }
    public DoublyNode<T>? Next { get; set; }

    public DoublyNode(T value)
    {
        Value = value;
        Previous = null;
        Next = null;
    }
}
