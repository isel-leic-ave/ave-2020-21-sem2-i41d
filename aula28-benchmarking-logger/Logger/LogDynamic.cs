using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class LogDynamic : AbstractLog
    {
        public LogDynamic() : this(new ConsolePrinter())
        {
        }

        public LogDynamic(IPrinter p) : base(p)
        {
        }

        static DynamicIGetterInstanceCreator dynamicIGetterInstanceCreator = new DynamicIGetterInstanceCreator();

        public override IEnumerable<IGetter> GetMembers(Type domainType)
        {
            // First check if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(domainType, out ms)) {
                ms = new List<IGetter>();
                foreach(MemberInfo m in domainType.GetMembers()) {
                    IGetter im;
                    if(ShouldLog(m, out im))
                    {
                        // 1. Create a new implementation of IGetter for member m in domain type t
                        // 2. Creates an instance of that type created in 1.
                        im = dynamicIGetterInstanceCreator.CreateIGetterFor(domainType, m);

                        // 3. Add that instnace to ms
                        ms.Add(im);
                    }
                }
                members.Add(domainType, ms);
            }
            return ms;
        }

    }
}
