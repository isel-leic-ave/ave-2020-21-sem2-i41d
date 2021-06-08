using System.Reflection;

public class GetterField : AbstractGetter
{
    private readonly FieldInfo field;

    public GetterField(FieldInfo field) : base(field.Name)
    {
        this.field = field;
    }

    public override object GetValue(object target)
    {
        return field.GetValue(target);
    }
}