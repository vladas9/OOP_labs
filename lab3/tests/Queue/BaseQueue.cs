[TestClass]
public abstract class BaseQueueTests<T>
{
    protected abstract IQueue<T> CreateQueue();

    [TestMethod]
    public void EnqueueDequeueTest()
    {
        var queue = CreateQueue();
        queue.Enqueue(GetSampleItem());
        queue.Enqueue(GetAnotherSampleItem());

        Assert.AreEqual(GetSampleItem(), queue.Dequeue());
        Assert.AreEqual(GetAnotherSampleItem(), queue.Dequeue());
        Assert.IsTrue(queue.IsEmpty());
    }

    [TestMethod]
    public void PeekTest()
    {
        var queue = CreateQueue();
        queue.Enqueue(GetSampleItem());
        queue.Enqueue(GetAnotherSampleItem());

        Assert.AreEqual(GetSampleItem(), queue.Peek());
        Assert.AreEqual(2, queue.Count);
    }

    [TestMethod]
    public void IsEmptyTest()
    {
        var queue = CreateQueue();

        Assert.IsTrue(queue.IsEmpty());
        queue.Enqueue(GetSampleItem());
        Assert.IsFalse(queue.IsEmpty());
    }

    [TestMethod]
    public void CountTest()
    {
        var queue = CreateQueue();
        Assert.AreEqual(0, queue.Count);

        queue.Enqueue(GetSampleItem());
        Assert.AreEqual(1, queue.Count);

        queue.Dequeue();
        Assert.AreEqual(0, queue.Count);
    }

    protected abstract T GetSampleItem();
    protected abstract T GetAnotherSampleItem();
}
