using System.Collections;


class ConvertIEnumerable: IEnumerable  {

    private FunctionDelegate mapper;
    private IEnumerable src;

    public ConvertIEnumerable(IEnumerable src, FunctionDelegate mapper) {
        this.mapper = mapper;
        this.src = src;

    }

    public IEnumerator GetEnumerator () {
        return new ConvertIEnumerator(src.GetEnumerator(), mapper);
    }
}


class ConvertIEnumerator : IEnumerator {
    private FunctionDelegate mapper;
    private IEnumerator src;

    public ConvertIEnumerator(IEnumerator src, FunctionDelegate mapper) {
        this.mapper = mapper;
        this.src = src;
    }

    public object Current { 
        get {
            return mapper(src.Current);
        } 
    }
    public bool MoveNext() {
        return src.MoveNext();
    }

    public void Reset() {
        src.Reset();
    }
}