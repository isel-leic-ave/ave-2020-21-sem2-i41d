using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class AppQueries7 {

    static IEnumerable<String> Lines(string path)
    {
        string line;
        using(StreamReader file = new StreamReader(path)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
     
    static IEnumerable<R> Convert<T, R>(IEnumerable<T> src, Func<T, R> mapper) {
        foreach (T o in src) {
            yield return mapper(o); // Returns an instance of T
        }
    }
    
    static IEnumerable<T> Filter<T>(IEnumerable<T> stds, Predicate<T> pred) {
        foreach (T o in stds) {
            if (pred(o)) 
                yield return o;
        }
    }

    static IEnumerable<T> Distinct<T>(IEnumerable<T> src) {
        HashSet<T> set = new HashSet<T>();
        foreach(T o in src)
            if(set.Add(o))
                yield return o;

    }
    
    static IEnumerable<T> Take<T>(IEnumerable<T> src, int nr) {
        int count = 0;
        foreach (T o in src) {
            if (++count > nr) yield break;
            yield return o;
        }
    }
    
    /**
     * Representa o domínio e o cliente App
     */
 
    public static void Run()
    {
        IEnumerable<string> names =
                    Take(
                        Convert(              // Seq<String>
                            Filter(           // Seq<Student>
                                Filter<Student>(       // Seq<Student>
                                    Convert<String, Student>(  // Seq<Student> 
                                        Lines("isel-AVE-2021.txt"),  // Seq<String>
                                        o => Student.Parse(o)),
                                    o => o.Number > 47000),
                                o => o.Name.Split(" ")[0].StartsWith("D")),
                            o => o.Name.Split(" ")[0]),
                        1);
        Console.WriteLine("------------ Listing Lazy yield Result --------------------");
        Console.ReadLine();
        foreach(object l in names)
            Console.WriteLine(l);
    }
}



