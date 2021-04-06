using System;
using Logger;

namespace App
{
    class Program
    {

        static void Main(string[] args)
        {
            Point p = new Point(7, 9);
            Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
            Student s2 = new Student(154134, "Xico", 1234, "xico");
            Account a = new Account(1300);
            // Console.WriteLine(p);
            // Console.WriteLine(s1);
            // Console.WriteLine(a);        
            Log l = new Log();
            l.Info(p);
            l.Info(s1);
            l.Info(s2);
            l.Info(a);
            
        }
    }
}
