[TestClass]
public class LinkedQueueTests : BaseQueueTests<double>
{
    protected override IQueue<double> CreateQueue()
    {
        return new LinkedQueue<double>();
    }

    protected override double GetSampleItem()
    {
        return 3.14;
    }

    protected override double GetAnotherSampleItem()
    {
        return 2.71;
    }
}
