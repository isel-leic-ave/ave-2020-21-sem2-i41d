public abstract class GetterBase : IGetter
{
    readonly string name;
    public GetterBase(string name)
    {
        this.name = name;
    }
    public string GetName() { return name; }

    public abstract object GetValue(object target);
}
