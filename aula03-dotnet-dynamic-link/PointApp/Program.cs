using System;
using PointLib;

namespace PointApp
{
    class Program
    {
        static void demo1()
        {
            Point p = new Point(3, 7);
            Console.WriteLine("Module = " + p.getModule());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            demo1();
        }
    }
}