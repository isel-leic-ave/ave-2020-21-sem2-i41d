using System;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log
    {

        private readonly IPrinter printer; 

        public Log(IPrinter p)
        {
            printer = p;
        }

        public Log() : this(new ConsolePrinter())
        {
            
        }

        public void Info(object o)
        {
            string output = Inspect(o);
            printer.Print(output);
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
            MemberInfo[] members = t.GetMembers();
            foreach (MemberInfo member in members)
            {
                if (ShouldLog(member))
                {

                    str.Append(member.Name);
                    str.Append(": ");
                    str.Append(GetValue(o, member));
                    //str.Append(field.GetValue(o));
                    str.Append(", ");
                }
            }
            return str.ToString();

        }

        private bool ShouldLog(MemberInfo m)
        {
            return m.MemberType == MemberTypes.Field || 
                (m.MemberType == MemberTypes.Method && (m as MethodInfo).GetParameters().Length == 0);

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
