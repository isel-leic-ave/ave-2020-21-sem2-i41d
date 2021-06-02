using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple=true)]
public class ToLogAttribute : Attribute {

    public ToLogAttribute(Type formatterType, params string[] args)
    {
        //... To Do...
    }

    public ToLogAttribute(String label)
    {
        //... To Do...
    }

    public ToLogAttribute()
    {
        
    }

}