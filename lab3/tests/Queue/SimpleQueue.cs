[TestClass]
public class SimpleQueueTests : BaseQueueTests<int>
{
    protected override IQueue<int> CreateQueue()
    {
        return new SimpleQueue<int>();
    }

    protected override int GetSampleItem()
    {
        return 42;
    }

    protected override int GetAnotherSampleItem()
    {
        return 99;
    }
}
