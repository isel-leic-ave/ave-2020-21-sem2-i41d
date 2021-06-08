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
        protected readonly Dictionary<Type, List<IGetter>> members = new Dictionary<Type, List<IGetter>>();

        public AbstractLog(IPrinter p )
        {
            printer = p;
        }

        public AbstractLog() : this(new ConsolePrinter())
        {
            
        }

        public abstract IEnumerable<IGetter> GetMembers(Type t);

        public void Info(Object target) {
            // option 1: String output = typeof(IEnumerable).IsAssignableFrom(target.GetType())
            // option 2: String output = target is IEnumerable
            // option 3
            IEnumerable seq = target as IEnumerable;
            String output = seq != null
                ? Inspect(seq)
                : Inspect(target);
            printer.Print(output);
        }

        public string Inspect(IEnumerable seq) {
            StringBuilder builder = new StringBuilder();
            builder.Append("Array of: ");
            builder.Append("\n");
            foreach(object item in seq) {
                builder.Append("\t");
                builder.Append(Inspect(item));
                builder.Append("\n");
            }
            return builder.ToString();
        }
        public string Inspect(Object target) {
            StringBuilder builder = new StringBuilder();
            builder.Append(target.GetType().Name);
            builder.Append("{");
            /**
             * Get information of members to log
             */
            builder.Append(LogMembers(target));
            /**
             * Finish output formatting
             */
            builder.Append("}");
            return builder.ToString();
        }
        public string LogMembers(Object target) {
            StringBuilder builder = new StringBuilder();
            // Inspect Fields
            foreach(IGetter m in GetMembers(target.GetType())) {
                builder.Append(m.GetName());
                builder.Append(':');
                builder.Append(m.GetValue(target));
                builder.Append(", ");
            }
            if(builder.Length != 0) builder.Length-= 2;
            return builder.ToString();
        }

        protected virtual bool ShoudlLog(MemberInfo m, out IGetter getter)
        {   
            getter = null;
            ///
            /// Check if ToLog annotation exists
            /// 
            if(!Attribute.IsDefined(m,typeof (ToLogAttribute))) return false;
            ///
            /// Check if is a field or parameterless method
            /// 
            if(m.MemberType == MemberTypes.Field) {
                getter = new GetterField((FieldInfo) m);
                return true;
            }
            if(m.MemberType == MemberTypes.Method) {
                MethodInfo mi = (MethodInfo) m;
                if(mi.GetParameters().Length == 0) {
                    getter = new GetterMethod((MethodInfo) m);
                    return true;
                }
            }
            return false;
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
