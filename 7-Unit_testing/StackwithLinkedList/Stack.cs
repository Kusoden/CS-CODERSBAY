using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackwithLinkedList;

public class Stack
{
    int size;
    public class Game
    {
        public string? data;
        public Game? link;
    }
    Game? top;

    public Stack() { this.top = null; }

    public void Push(string value)
    {
        Game temp = new()  /*CURVED BRACKET = instead of*/
        {
            data = value,/*temp.data = value;*/
            link = top/*temp.link = top*/
        };
        top = temp;
        size++;
    }


    public int Size()
    {
        return size;
    }

    public string Pop()
    {
        if (top == null)
            throw new NullReferenceException("it's Empty");
        else
        {
            string poppedData = top.data; // Save the data of the top to return it
            top = top.link;
            size--;
            return poppedData;
        }

    }

    public string Peek()
    {
        if (top == null)
            throw new NullReferenceException("it's Empty!");
        else
        {
            if (top.data == null)
                throw new NullReferenceException("no data found");
            else
                return top.data;
    }

}

    public void Display()
    {
        if (top == null)
            throw new NullReferenceException("it's Empty");
        else
        {
            Game? temp = top;
            while (temp != null)
            {
                Console.WriteLine(temp.data);
                temp = temp.link;
            }
        }
    }
    public string[] Pop(int value)
    {
        if (value > size)
        {
            throw new IndexOutOfRangeException("Index out of Bound!");
        }
        else
        {
            string[] poppedGames = new string[Math.Min(value, size)];
            for (int i = 0; i < poppedGames.Length; i++)
                poppedGames[i] = Pop();
            return poppedGames;
        }

    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        if (top == null)
            return "";
        else
        {
            Game temp = top;
            while (temp != null)
            {
                stringBuilder.Append(temp.data);
                stringBuilder.Append(", ");
                temp = temp.link;
            }
            return stringBuilder.ToString();
        }
    }
}