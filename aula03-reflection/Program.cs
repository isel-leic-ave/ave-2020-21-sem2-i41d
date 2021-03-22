using System;
using System.Reflection;

namespace RestSharpApp
{
    class Program
    {
        static void Main(string[] args){
            Assembly asm = Assembly.LoadFrom("RestSharp.dll");
            Type[] types = asm.GetTypes();
            foreach(Type t in types){
                Console.WriteLine(t.Name);
                MethodInfo[] methods = t.GetMethods();
                foreach(MethodInfo m in methods){
                    Console.WriteLine("\t"+m.Name);
                }
            }
        }
    }
}