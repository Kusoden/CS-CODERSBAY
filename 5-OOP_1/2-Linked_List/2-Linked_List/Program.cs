﻿using System;
using System.Collections.Generic;

namespace _2_Linked_List;

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
        int removableIndex = 1;
        Console.WriteLine("Elements inside Linked List: " + numberList.ToString());/* Display the list*/
       
        Console.WriteLine("\nSize of the Linked List: " + numberList.Size());/* Get the size of the list*/
       
        Console.WriteLine("\nElements inside Empty List: " + emptyList.ToString());
       
        int element = numberList.GetValue(1);
        Console.WriteLine("\nElement at index 1: " + element);
       
        int removedElement = numberList.Remove(removableIndex);/* Remove an element at a specific index*/
        Console.WriteLine("\n----Removed element at index " + removableIndex + ": " + removedElement);
       
        Console.WriteLine("\n+Updated Linked List: " + numberList.ToString());/*Display the updated list*/

        numberList.Add(1, 77);        /*Add elements at specific index*/
        numberList.Add(3, 999);
       
        Console.WriteLine("\nLinked List after adding elements at specific indices: " + numberList.ToString());/*Display the list after adding elements at specific indices*/

        Console.WriteLine("\n---------------------");
        Console.WriteLine("DoublyLinkedList");

        Doubly_Linked_List<int> numberList2 = new();
        
        /*
        if(numberList.Remove(4) != null) { numberList.Remove(4); }

        try {
            numberList.Remove(4);
        } catch     (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        */

        numberList2.Add(1);
        numberList2.Add(2);
        numberList2.Add(3);
        numberList2.Add(4);
        numberList2.Add(5);
        Console.WriteLine("\nElements inside Linked List: " + numberList2.ToString());/* Display the list*/
       
        Console.WriteLine("\nSize of the Linked List: " + numberList2.Size());/* Get the size of the list*/

        int element2 = numberList2.Get(3).Value;
        Console.WriteLine("\nElement at index 1: " + element2);
       
        int removedElement2 = numberList2.Remove(removableIndex);/* Remove an element at a specific index*/
        Console.WriteLine("\n----Removed element at index " + removableIndex + ": " + removedElement2);
       
        Console.WriteLine("\n+Updated Linked List: " + numberList2.ToString());/*Display the updated list*/
        Console.WriteLine("\n LinkedReversed List: " + numberList2.ToStringReverse());           
        numberList2.Add(2, 55);        /*Add elements at specific index*/
        numberList2.Add(3, 999);
       
        Console.WriteLine("\nLinked List after adding elements at specific indices: " + numberList2.ToString());

    }
}