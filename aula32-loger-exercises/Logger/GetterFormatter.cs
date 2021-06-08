using System;
using System.Reflection;

namespace Logger
{
    internal class GetterFormatter : IGetter
    {
        private readonly IFormatter formatter;
        private readonly IGetter getter;

        public GetterFormatter(IGetter getter, Type formatterType, object[] ctorArgs) {
            this.formatter = (IFormatter)Activator.CreateInstance(formatterType, ctorArgs);
            this.getter = getter;
        }

        public string GetName()
        {
            return getter.GetName();
        }

        public object GetValue(object target) {
            return formatter.Format(getter.GetValue(target));
        }
    }
}