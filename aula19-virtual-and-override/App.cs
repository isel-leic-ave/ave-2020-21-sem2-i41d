using System;

class A { 
    /**
     * NOT Virtual by default
     */
    public virtual void Foo() { Console.WriteLine("I am A"); }
}

class B : A  { public override void Foo() { Console.WriteLine("I am B"); }}



public class App {

    static void Print(A a) {
        a.Foo();
    }

    public static void Main(String[] args) {
        Print(new A());
        Print(new B());
    }
}