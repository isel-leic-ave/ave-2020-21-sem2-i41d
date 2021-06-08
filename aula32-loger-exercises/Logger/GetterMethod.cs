using System.Reflection;

public class GetterMethod : AbstractGetter
{
    private readonly MethodInfo method;

    public GetterMethod(MethodInfo method) : base(method.Name)
    {
        this.method = method;
    }

    public override object GetValue(object target)
    {
        return method.Invoke(target, null);
    }
}