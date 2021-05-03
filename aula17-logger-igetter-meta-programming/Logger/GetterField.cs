using System.Reflection;

public class GetterField : IGetter
{
    private readonly FieldInfo field;

    public GetterField(FieldInfo field)
    {
        this.field = field;
    }

    public string GetName()
    {
        return field.Name;
    }

    public object GetValue(object target)
    {
        return field.GetValue(target);
    }
}