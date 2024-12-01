public class CircularQueue<T> : IQueue<T>
{
    private T[] _items;
    private int _head = 0, _tail = 0, _count = 0;

    public CircularQueue(int capacity)
    {
        _items = new T[capacity];
    }

    public void Enqueue(T item)
    {
        if (_count == _items.Length) throw new InvalidOperationException("Queue is full.");
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        T item = _items[_head];
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        return _items[_head];
    }

    public bool IsEmpty() => _count == 0;

    public int Count => _count;
}
