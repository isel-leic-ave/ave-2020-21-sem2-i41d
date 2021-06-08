using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log : AbstractLog
    {
        public Log()
        {
        }

        public Log(IPrinter p) : base(p)
        {
        }

        

        public override IEnumerable<IGetter> GetMembers(Type t)
        {
            // First check if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<IGetter>();
                foreach(MemberInfo m in t.GetMembers()) {
                    IGetter getter = null; 
                    if(ShoudlLog(m, out getter)) {
                        ms.Add(getter);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }

        protected override bool ShoudlLog(MemberInfo m, out IGetter getter)
        {   
            getter = null;
            ///
            /// Check if ToLog annotation exists
            /// 
            ToLogAttribute attr = (ToLogAttribute)m.GetCustomAttribute(typeof(ToLogAttribute));
            if(attr == null) return false;
            ///
            /// Check if is a field or parameterless method
            /// 
            if(m.MemberType == MemberTypes.Field) {
                getter = new GetterField((FieldInfo) m);
            }
            if(m.MemberType == MemberTypes.Method) {
                MethodInfo mi = (MethodInfo) m;
                if(mi.GetParameters().Length == 0) {
                    getter = new GetterMethod((MethodInfo) m);
                }
            }
            if(getter == null) 
                return false;
            if(attr.FormatterType != null)
                getter = new GetterFormatter(getter, attr.FormatterType, attr.CtorArgs);
            return true;
        }
    }
}
