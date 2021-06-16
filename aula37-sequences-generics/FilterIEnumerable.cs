using System.Collections;

internal class FilterIEnumerable : IEnumerable
{
    private IEnumerable src;
    private PredicateDelegate pred;

    public FilterIEnumerable(IEnumerable src, PredicateDelegate pred)
    {
        this.src = src;
        this.pred = pred;
    }

    public IEnumerator GetEnumerator()
    {
        return new FilterIEnumerator(src.GetEnumerator(), pred);
    }
}

internal class FilterIEnumerator : IEnumerator
{
    private IEnumerator src;
    private PredicateDelegate pred;

    public FilterIEnumerator(IEnumerator enumerator, PredicateDelegate pred)
    {
        this.src = enumerator;
        this.pred = pred;
    }

    public object Current => src.Current;

    public bool MoveNext()
    {
        while(src.MoveNext()) {
             if(pred(src.Current))
                return true;
        }
            
        return false;
    }

    public void Reset()
    {
        src.Reset();
    }
}