using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple=true)]
public class ToLogAttribute : Attribute {
    public ToLogAttribute(String label)
    {
        //... To Do...
    }

    public ToLogAttribute()
    {
        
    }

}