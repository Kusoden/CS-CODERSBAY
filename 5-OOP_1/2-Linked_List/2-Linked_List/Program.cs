using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<int> numberList = new();
        LinkedList<int> emptyList = new();

        numberList.Add(1);
        numberList.Add(2);
        numberList.Add(3);
        numberList.Add(4);
        int removableIndex = 0;
        Console.WriteLine("Elements inside Linked List: " + numberList.ToString());/* Display the list*/
        Console.WriteLine("\nSize of the Linked List: " + numberList.Size());/* Get the size of the list*/

        int element = numberList.Get(1);
        Console.WriteLine("\nElement at index 1: " + element);

        int removedElement = numberList.Remove(removableIndex);/* Remove an element at a specific index*/
        Console.WriteLine("\n----Removed element at index "+ removableIndex + ": " + removedElement);

     
        Console.WriteLine("\n+Updated Linked List: " + numberList.ToString());/*Display the updated list*/

        numberList.Add(1, 77);        /*Add elements at specific index*/
        numberList.Add(3, 999);
         
        Console.WriteLine("\nLinked List after adding elements at specific indices: " + numberList.ToString());/*Display the list after adding elements at specific indices*/
    }
}