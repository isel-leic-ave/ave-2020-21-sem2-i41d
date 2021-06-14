using System.Collections;

internal class TakeIEnumerable : IEnumerable
{
    private IEnumerable src;
    private int nr;

    public TakeIEnumerable(IEnumerable src, int nr)
    {
        this.src = src;
        this.nr = nr;
    }

    public IEnumerator GetEnumerator()
    {
        return new TakeIEnumerator(src.GetEnumerator(),nr);
    }
}

internal class TakeIEnumerator : IEnumerator
{
    private IEnumerator src;
    private int nr;
    private int count; 

    public TakeIEnumerator(IEnumerator enumerator, int nr)
    {
        this.src = enumerator;
        this.nr = nr;
    }

    public object Current => src.Current;

    public bool MoveNext()
    {
        return count++ < nr && src.MoveNext();
    }

    public void Reset()
    {
        count = 0;
        src.Reset();
    }
}