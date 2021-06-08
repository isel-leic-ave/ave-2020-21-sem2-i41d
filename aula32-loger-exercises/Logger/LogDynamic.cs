using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class LogDynamic : AbstractLog
    {
        public LogDynamic()
        {
        }

        public LogDynamic(IPrinter p) : base(p)
        {
        }

        public override IEnumerable<IGetter> GetMembers(Type t)
        {
            // First check if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(t, out ms)) {
                DynamicGetterBuider builder = new DynamicGetterBuider(t);
                ms = new List<IGetter>();
                foreach(MemberInfo m in t.GetMembers()) {
                    IGetter getter = null; 
                    if(ShoudlLog(m, out getter)) {
                        // 1. Create the class that extends AbstractGetter for that member m in domain type t.
                        Type getterType = builder.GenerateGetterFor(m);
                        // 2. Instantiate the class created on 1.
                        getter = (IGetter) Activator.CreateInstance(getterType);
                        ms.Add(getter);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }
    }
}
