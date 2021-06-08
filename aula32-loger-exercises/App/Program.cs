using System;
using System.Text;
using Logger;

namespace App
{
    class BufferPrinter : IPrinter
    {
        public readonly StringBuilder buffer = new StringBuilder();
        public void Print(string output)
        {
            buffer.Append(output);
        }
    }
    class Program
    {
        static readonly BufferPrinter printer;
        static readonly AbstractLog logReflect, logDynamic;
        static readonly Student maria;
        static readonly Point pt99 = new Point(99, 77);

        static void Main(string[] args)
        {
            // NBench.Bench(Program.BenchLogReflectStudent); // JAVA Program::BenchLogReflectStudent
            // NBench.Bench(Program.BenchLogDynamicStudent);
            // NBench.Bench(Program.BenchLogReflectPoint);
            // NBench.Bench(Program.BenchLogDynamicPoint);
            
            
            Demo();
            
        }

        static void Demo() 
        {
            Point p = new Point(7, 9);
            Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
            Student s2 = new Student(235474, "Maria Joana", 2356, "maria");
            Student s3 = new Student(761354, "Jaquina Ambrosia", 9872, "joaquina");
            Account a = new Account(1300);
            Student [] arr = {s1, s2, s3};
            Log log = new Log();
            log.Info(p);
            log.Info(arr);
            log.Info(a);
        }


        /// <summary>
        /// Setup of Log and a Student.
        /// </summary>
        static Program()
        {
            printer = new BufferPrinter();
            logReflect = new Log(printer);
            logDynamic = new LogDynamic(printer);
            maria = new Student(235474, "Maria Joana", 2356, "maria");
        }

        /// <summary>
        /// Measure peformance of Log (Reflect) with a Student
        /// </summary>
        public static void BenchLogReflectStudent()
        {
            printer.buffer.Clear();
            logReflect.Info(maria);
        }


        /// <summary>
        /// Measure peformance of LogDynamic with a Student
        /// </summary>
        public static void BenchLogDynamicStudent()
        {
            printer.buffer.Clear();
            logDynamic.Info(maria);
        }

    	public static void BenchLogReflectPoint()
        {
            printer.buffer.Clear();
            logReflect.Info(pt99);
        }


        /// <summary>
        /// Measure peformance of LogDynamic with a Student
        /// </summary>
        public static void BenchLogDynamicPoint()
        {
            printer.buffer.Clear();
            logDynamic.Info(pt99);
        }


    }
}
