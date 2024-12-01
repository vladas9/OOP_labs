public class SimpleQueue<T> : IQueue<T>
{
    private List<T> _items = new List<T>();

    public void Enqueue(T item) => _items.Add(item);

    public T Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        T item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        return _items[0];
    }

    public bool IsEmpty() => !_items.Any();

    public int Count => _items.Count;
}
