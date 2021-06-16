using System;
using System.Collections.Generic;

namespace aula37_generics
{

    interface I<U> {}
    class A<T> where T : IComparable{ 
        public T Foo() { return default(T); } // It is NOT a Generic Method

        public int Bar<U>(T msg, U other) {
            return msg.ToString().Length + other.GetHashCode();
        }
    }

    class Point {}

    class Program
    {
        static void Main(string[] args)
        {
            A<String> a1 = new A<string>();
            A<int> a2;
            // A<Point> a3;  // Point does not fulfil the constraint IComparable

            a1.Bar<Point>("super", new Point());
            // a1.Bar<Point>("super", "isel"); //  COMPILATION ERROR

            // List<Point> l = new List<Point>();
            // l.Add("isel");  //  COMPILATION ERROR

            // List<int> nrs = new List<int>();
            // nrs.Add("isel");  //  COMPILATION ERROR
        }
    }
}
