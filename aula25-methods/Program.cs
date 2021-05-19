using System;

namespace aula25_methods
{

    public class Person
    {
        public Person(string name)
        {
        }
        public void Foo() {}

        public virtual void Print() { Console.WriteLine("I am a Person");}
    }
    public class Student : Person 
    {
        public Student(string name) : base(name){}

        /// <summary>
        /// Print is a VIRTUAL method => can be overriden 
        /// </summary>
        public override void Print() { Console.WriteLine("I am a Student");}
        /// <summary>
        /// Foo is NOT virtual => cannot be ovveriden
        /// </summary>
        // public override void Foo() { }
    }


    public struct Point { 
        int x; int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Bar() {}
    }

class Triangle {
    Point p1, p2, p3; // Stored in-place => Heap
}

class Program
{
    static void Main(string[] args)
    {
        Person p = new Person("Lost name"); // stored in Heap
        Point pt = new Point();  // stored in Stack
        Point pt2 = new Point(5, 7);  // stored in Stack
        Triangle t = new Triangle(); // stored in Heap
        p.Foo();
        pt.Bar();
        // !!!! pt cannnot be null ever !!!!!
        // if(pt != null) pt.Bar();
    }
}
}
