var cache = new LRUCache(2);

cache.Put(1, 1);
cache.Put(2, 2);
Console.WriteLine(cache.Get(1));
cache.Put(3, 3);
Console.WriteLine(cache.Get(2));
cache.Put(4, 4);
Console.WriteLine(cache.Get(1));
Console.WriteLine(cache.Get(3));
Console.WriteLine(cache.Get(4));


class LRUCache
{
    private int _capacity;
    private Dictionary<int, LinkedListNode<int>> _tracker;
    private LinkedList<int> _cache;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new LinkedList<int>();
        _tracker = new Dictionary<int, LinkedListNode<int>>();
    }

    public int Get(int key)
    {
        if (_tracker.TryGetValue(key, out var value) == false) return -1;

        if(value.List == null)
        {
            _tracker.Remove(key);
            return -1;
        }

        _cache.Remove(value);
        _cache.AddLast(value);
        return value.Value;
    }

    public void Put(int key, int value)
    {
        if (_tracker.TryGetValue(key, out var existing))
        {
            _cache.Remove(existing);
            existing.Value = value;
            _cache.AddLast(existing);

            var node = _tracker[key];
            if (node.List != null)
            {
                node.Value = value;
                _cache.Remove(node);
                _cache.AddFirst(node);
                return;
            }
            else
                _tracker.Remove(key);
        }

        if (_tracker.Count >= _capacity)
        {
            _cache.RemoveFirst();
        }

        var newValue = _cache.AddLast(value);
        _tracker.Add(key, newValue);
    }
}