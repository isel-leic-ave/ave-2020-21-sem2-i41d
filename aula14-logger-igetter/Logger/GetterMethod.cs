using System.Reflection;

public class GetterMethod : IGetter
{
    private readonly MethodInfo method;

    public GetterMethod(MethodInfo method)
    {
        this.method = method;
    }

    public string GetName()
    {
        return method.Name;
    }

    public object GetValue(object target)
    {
        return method.Invoke(target, null);
    }
}