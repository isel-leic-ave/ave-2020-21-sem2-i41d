using System;
using System.Text;
using Logger;

namespace App
{
    class BufferPrinter : IPrinter
    {
        public StringBuilder buffer = new StringBuilder();
        public void Print(string output)
        {
            buffer.Append(output);
        }
    }
    class Program
    {
        static readonly BufferPrinter printer = new BufferPrinter();
        static readonly Log logReflect = new Log(printer);
        static readonly LogDynamic logDynamic = new LogDynamic(printer);
        static readonly Student maria = new Student(763547, "Maria Papoila", 3547, "maria");
            

        static void Main(string[] args)
        {
            NBench.Bench(Program.BenchLogReflectionStudent);
            NBench.Bench(Program.BenchLogDynamicStudent);
        }

        public static void BenchLogReflectionStudent() {
            printer.buffer.Clear();
            logReflect.Info(maria);
        }
        public static void BenchLogDynamicStudent() {
            printer.buffer.Clear();
            logDynamic.Info(maria);
        }


        static void Demo()
        {
            //
            // Domain objects
            //
            Point p = new Point(7, 9);
            Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
            Student s2 = new Student(324234, "Xico", 1234, "xico");
            Student s3 = new Student(763547, "Maria Papoila", 3547, "maria");
            Student[] arr = {s1, s2, s3};
            Account a = new Account(1300);
            //
            // Logging
            //
            Log l = new Log();
            l.Info(p);
            l.Info(s1);
            l.Info(a);
            l.Info(arr);
        }
    }
}
