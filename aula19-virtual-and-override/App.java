
class A { 
    /**
     * Virtual by default
     */
    public void Foo() { System.out.println("I am A"); }
}

class B extends A  { public void Foo() { System.out.println("I am B"); }}



public class App {

    static void Print(A a) {
        a.Foo();
    }

    public static void main(String[] args) {
        Print(new A());
        Print(new B());
    }
}