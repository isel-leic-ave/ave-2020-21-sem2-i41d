using System;

namespace aula20_instances
{

    public class Student
    {
        public int nr;
        public string name;

        public Student(int nr, string name)
        {
            this.nr = nr;
            this.name = name;
        }

        public override string ToString()
        {
            return "Student: " + nr + " " + name;
        }
    }

    public struct Size{
        public int height;
        public int weight;

        public Size(int height, int weight)
        {
            this.height = height;
            this.weight = weight;
        }

        public override string ToString()
        {
            return "Size: " + height + " " + weight;
        }
    }

    struct WrapInt { int dum; }

    class Program
    {
        static void Main(string[] args) {
            // Processing something
            // ....
            Foo();
            //...
            // Processing something
        }

        /// <summary>
        /// An auxiliary method doiing sometning.
        /// ??? What is the life cycle of each instance ???
        /// ??? When the VM clear those instances???
        /// </summary>
        static void Foo()
        {

            WrapInt w = new WrapInt();
            int n = 7;
            
            Student s1 = new Student(62354, "Ze Manel");
            Size size1 = new Size(89, 73);

            Student s2 = s1; 
            s2.nr = 99;     // !!! s2 and s1 have the same Reference / Handle
            s2.name = "99";

            Size size2 = size1;
            size2.height = 99;  // size2 stores a different instance than size1
            size2.weight = 99;

            Console.WriteLine("s1 = " + s1.ToString());
            Console.WriteLine("size1 = " + size1.ToString());

            object o = size1; // box Size

        }
    }
}
