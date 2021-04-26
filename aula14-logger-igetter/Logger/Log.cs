using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log
    {

        private readonly IPrinter printer; 
        private readonly Dictionary<Type, List<MemberInfo>> members = new Dictionary<Type, List<MemberInfo>>();

        public Log(IPrinter p)
        {
            printer = p;
        }

        public Log() : this(new ConsolePrinter())
        {
            
        }

        public void Info(object o)
        {
            //
            // Check if o is an IEnumerable
            //
            // Option 1: string output = typeof(IEnumerable).IsAssignableFrom(o.GetType())
            // Option 2: string output = o is IEnumerable
            // Option 3: 
            IEnumerable seq = o as IEnumerable; // as is translated to isinst
            string output = seq != null
                ? Inspect(seq)
                : Inspect(o);
            printer.Print(output);
        }

        private string Inspect(IEnumerable seq) {
            StringBuilder str = new StringBuilder();
            str.Append("Array of:\n");
            foreach(object item in seq) {
                str.Append("\t");
                str.Append(Inspect(item));
                str.Append("\n");
            }
            return str.ToString();
        }

        private string Inspect(object o)
        {
            string membersStr = LogMembers(o);
            return membersStr;
        }

        private string LogMembers(object o)
        {
            Type t = o.GetType();

            StringBuilder str = new StringBuilder();
            foreach (MemberInfo member in GetMembers(t))
            {
                str.Append(member.Name);
                str.Append(": ");
                str.Append(GetValue(o, member));
                //str.Append(field.GetValue(o));
                str.Append(", ");
            }
            if(str.Length > 0) str.Length -= 2;
            return str.ToString();

        }

        private IEnumerable<MemberInfo> GetMembers(Type t)
        {
            // First checj if exist in members dictionary
            List<MemberInfo> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<MemberInfo>();
                foreach(MemberInfo m in t.GetMembers()) {
                    if(ShouldLog(m))
                        ms.Add(m);
                }
                members.Add(t, ms);
            }
            return ms;
        }

        private bool ShouldLog(MemberInfo m)
        {
            /**
             * Check if it is annotated with ToLog
             */
            // Option 1: 
            // Object attr = Attribute.GetCustomAttribute(m,typeof(ToLogAttribute));
            // if(attr == null) return false;
            // Option 2: 
            // object[] attrs = m.GetCustomAttributes(typeof(ToLogAttribute), true);
            // if(attrs.Length == 0) return false;
            // Option 3: 
            if(!Attribute.IsDefined(m,typeof(ToLogAttribute))) return false;
            /**
             * Check if it is a Field
             */
            if(m.MemberType == MemberTypes.Field) return true;
            /**
             * Check if it is a parameterless method
             */
            return m.MemberType == MemberTypes.Method 
                && (m as MethodInfo).GetParameters().Length == 0;
        }
        private object GetValue(object target, MemberInfo m) {
            switch(m.MemberType)
            {
                case MemberTypes.Field:
                    return (m as FieldInfo).GetValue(target);
                case MemberTypes.Method: 
                    return (m as MethodInfo).Invoke(target, null);
                default:
                    throw new InvalidOperationException("Non properly member for logging!");
            }
        }

        private class ConsolePrinter : IPrinter
        {
            public void Print(string output)
            {
                Console.WriteLine(output);
            }
        }
    }
}
