using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public abstract class AbstractLog
    {

        private readonly IPrinter printer; 
        private protected Dictionary<Type, List<IGetter>> members = new Dictionary<Type, List<IGetter>>();

        public AbstractLog(IPrinter p)
        {
            printer = p;
        }

        public AbstractLog() : this(new ConsolePrinter())
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
            foreach (IGetter member in GetMembers(t)) // Compilador de C# => cast explicito de IGetter para MemberInfo
            {
                str.Append(member.GetName());
                str.Append(": ");
                str.Append(member.GetValue(o));
                str.Append(", ");
            }
            if(str.Length > 0) str.Length -= 2;
            return str.ToString();

        }

        public abstract IEnumerable<IGetter> GetMembers(Type t);

        /// <summary>
        /// Validate if that member m should be logged, i.e. it must have a ToLog annotation
        /// and be a field or a parameterless method.
        /// Also it may return an instance of GetterField or GetterMethod.
        /// </summary>
        protected virtual bool ShouldLog(MemberInfo m, out IGetter getter)
        {
            getter = null;
            /**
             * Check if it is annotated with ToLog
             */
            if(!Attribute.IsDefined(m,typeof(ToLogAttribute))) return false;
            /**
             * Check if it is a Field
             */
            if(m.MemberType == MemberTypes.Field)
            {
                getter = new GetterField((FieldInfo) m);
                return true;
            }
            /**
             * Check if it is a parameterless method
             */
            if(m.MemberType == MemberTypes.Method  && (m as MethodInfo).GetParameters().Length == 0)
            {
                getter = new GetterMethod((MethodInfo) m);
                return true;
            }
            return false;
        }
        
        /// Suppressed in optimized version of Logger
        /*
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
        */

        private class ConsolePrinter : IPrinter
        {
            public void Print(string output)
            {
                Console.WriteLine(output);
            }
        }
    }
}
