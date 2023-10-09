using System;
using System.Collections.Generic;
using Xunit;
using QueueDoubleLinkedList;
using System.Drawing;

namespace Queue_Test;

public class UnitTest1
{
    [Fact]
    public void Enqueue_Test()
    {
        QueueLL theQueue = new();
        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        Assert.Equal(2, theQueue.Size());
        theQueue.Enqueue(3);
        theQueue.Enqueue(4);
        Assert.Equal(4, theQueue.Size());
    }
    [Fact]
    public void Size_Test()
    {
        QueueLL theQueue = new();
        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        theQueue.Enqueue(3);

        Assert.Equal(3, theQueue.Size());
        theQueue.Enqueue(4);
        theQueue.Enqueue(5);
        Assert.Equal(5, theQueue.Size());
    }

    [Fact]
    public void Dequeue_Test()
    {
        QueueLL theQueue = new();
        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        theQueue.Enqueue(3);

        Assert.Equal(3, theQueue.Size());

        theQueue.Dequeue(1);

        Assert.Equal(2, theQueue.Size());
        Assert.Equal("2|3|", theQueue.ToString());

        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        theQueue.Enqueue(3);
        Assert.Equal(5, theQueue.Size());
        theQueue.Dequeue(5);
        Assert.Equal(0, theQueue.Size());
        Assert.Throws<NullReferenceException>(() => theQueue.Dequeue());
    }

    [Fact]
    public void ToString_Test()
    {
        QueueLL theQueue = new();
        theQueue.Enqueue(1);
        theQueue.Enqueue(2);
        theQueue.Enqueue(3);

        Assert.Equal("1|2|3|", theQueue.ToString());
    }

    [Fact]
    public void Deq_Test()
    {
        QueueLL emptyQ = new();

        Exception ex = Assert.Throws<NullReferenceException>(() => emptyQ.Dequeue());
        Assert.Equal("The Queue is ALREADY empty!", ex.Message);
    }

    [Fact]
    public void DeqArray_Test()
    {
        QueueLL theQueue = new();
        theQueue.Enqueue(1);

        int[] Dequeue = theQueue.Dequeue(1);

        Exception ex = Assert.Throws<IndexOutOfRangeException>(() => Dequeue = theQueue.Dequeue(3));
        Assert.Equal("Index is out of range!", ex.Message);

        Assert.Single(Dequeue);

        Assert.Equal(0, theQueue.Size());
    }
}