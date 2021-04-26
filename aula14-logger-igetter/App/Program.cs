using System;
using Logger;

namespace App
{
    class Program
    {

        static void Main(string[] args)
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
