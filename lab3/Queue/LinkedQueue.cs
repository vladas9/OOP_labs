public class LinkedQueue<T> : IQueue<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node? Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count = 0;

    public void Enqueue(T item)
    {
        Node newNode = new Node(item);
        if (_tail != null) _tail.Next = newNode;
        _tail = newNode;
        if (_head == null) _head = newNode;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        T item = _head!.Data;
        _head = _head.Next;
        if (_head == null) _tail = null;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Queue is empty.");
        return _head!.Data;
    }

    public bool IsEmpty() => _head == null;

    public int Count => _count;
}
