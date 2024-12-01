public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    bool IsEmpty();
    int Count { get; }
}
