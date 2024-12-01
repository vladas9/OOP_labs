[TestClass]
public class CircularQueueTests : BaseQueueTests<string>
{
    protected override IQueue<string> CreateQueue()
    {
        return new CircularQueue<string>(10);
    }

    protected override string GetSampleItem()
    {
        return "Hello";
    }

    protected override string GetAnotherSampleItem()
    {
        return "World";
    }
}
