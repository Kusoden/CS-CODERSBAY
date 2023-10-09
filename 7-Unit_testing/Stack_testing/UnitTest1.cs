using System;
using System.Collections.Generic;
using Xunit;
using StackwithLinkedList; /*TO HAVE ACCESS TO THE PROJECT, FIRST I SHOULD RIGHT CLICK DEPENDENCIES IN SOL.EXPLOR. and then add project and using {projname}*/

namespace Stack_testing;

public class StackTests
{
    

    [Fact]
    public void Push_Test()
    {
        Stack library = new();

        library.Push("Destiny");
        library.Push("Warcraft 3");
        library.Push("Final Fantasy XV");

        Assert.Equal(3, library.Size()); /*Test if there all 3 pushed into Stack*/
    }

    [Fact]
    public void Pop_Test()
    {
        Stack library = new();

        library.Push("Destiny");
        library.Push("Warcraft 3");
        library.Push("Final Fantasy XV");

        Assert.Equal("Final Fantasy XV", library.Pop());/*test pop last, and size should be 3*/
        Assert.Equal(2, library.Size());
    }

    [Fact]
    public void Peek_Test()
    {
        Stack library = new();

        library.Push("Destiny");
        library.Push("Warcraft 3");
        library.Push("Final Fantasy XV");

        Assert.Equal("Final Fantasy XV", library.Peek());/*Peek at last one, and size should be 3*/
        Assert.Equal(3, library.Size());
    }

    [Fact]
    public void Pop_Array_Test()
    {
        Stack library = new();

        library.Push("Destiny");
        library.Push("Warcraft 3");
        library.Push("Final Fantasy XV");

        string[] poppedGames = new string[2];
        for (int i = 0; i < poppedGames.Length; i++)
        {
            poppedGames[i] = library.Pop();
        }
        Assert.Equal(1, library.Size());/*there should only be 1 game*/
        Assert.Equal(2, poppedGames.Length); /*2 games in the popped Array*/
    }

    [Fact]
    public void ExcPop_Test()/* VERIFY whats inside <> thrown when attempting to do whats after arrow*/
    {
        Stack library = new();
        Exception ex = Assert.Throws<NullReferenceException>(() => library.Pop());
        Assert.Equal("it's Empty", ex.Message);
    }

    [Fact]
    public void ExcPeek_Test()
    {
        Stack library = new();
        Exception ex = Assert.Throws<NullReferenceException>(() => library.Peek());
        Assert.Equal("it's Empty!", ex.Message);
    }

    [Fact]
    public void ExcPopArray_Test() 
    {
        Stack library = new();
        library.Push("The Sims 4");
        library.Push("Warcraft 3");

        string[] poppedGames = library.Pop(2);

        Exception ex = Assert.Throws<IndexOutOfRangeException>(() => library.Pop(3)); /*Verify outofrange exception*/
        Assert.Equal("Index out of Bound!", ex.Message);

        Assert.Equal(new [] { "Warcraft 3", "The Sims 4" }, poppedGames); /*check if the library includes same games as the new array*/
    }
}
