using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log : AbstractLog
    {
        public Log() : this(new ConsolePrinter())
        {
        }

        public Log(IPrinter p) : base(p)
        {
        }

        public override IEnumerable<IGetter> GetMembers(Type t)
        {
            // First checj if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<IGetter>();
                foreach(MemberInfo m in t.GetMembers()) {
                    IGetter im;
                    if(ShouldLog(m, out im))
                    {
                        ms.Add(im);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }

    }
}
