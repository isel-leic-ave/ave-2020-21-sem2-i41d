using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
public class ToLogAttribute : Attribute {

    public ToLogAttribute(string label = "") {

    }

    public ToLogAttribute(Type formatterType, params object[] ctorArgs) {
        FormatterType = formatterType;
        CtorArgs = ctorArgs;
    }

    public Type FormatterType { get; }
    public object[] CtorArgs { get; }
}