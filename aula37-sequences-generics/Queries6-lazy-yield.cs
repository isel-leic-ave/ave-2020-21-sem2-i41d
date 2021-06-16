using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class AppQueries6 {

    static IEnumerable Lines(string path)
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
     
    static IEnumerable Convert(IEnumerable src, FunctionDelegate mapper) {
        foreach (object o in src) {
            yield return mapper(o);
        }
    }
    
    static IEnumerable Filter(IEnumerable stds, PredicateDelegate pred) {
        foreach (object o in stds) {
            if (pred(o)) 
                yield return o;
        }
    }

    static IEnumerable Distinct(IEnumerable src) {
        HashSet<object> set = new HashSet<object>();
        foreach(object o in src)
            if(set.Add(o))
                yield return o;

    }
    
    static IEnumerable Take(IEnumerable src, int nr) {
        int count = 0;
        foreach (object o in src) {
            if (++count > nr) yield break;
            yield return o;
        }
    }
    
    /**
     * Representa o domínio e o cliente App
     */
 
    public static void Run()
    {
        IEnumerable items = Convert(Lines("isel-AVE-2021.txt"), o => Student.Parse((string) o));

        IEnumerable names =
            Take(
                Convert(              // Seq<String>
                    Filter(           // Seq<Student>
                        Filter(       // Seq<Student>
                            Convert(  // Seq<Student> 
                                Lines("isel-AVE-2021.txt"),  // Seq<String>
                                o => { 
                                    object ret = Student.Parse((string) o); 
                                    Console.WriteLine("Convert to Student"); 
                                    return ret;  
                                }),
                            o => {
                                Console.WriteLine("Filtering... "); 
                                return ((Student) o).Number > 47000;
                            }),
                        o => ((Student) o).Name.Split(" ")[0].StartsWith("D")),
                    o => ((Student) o).Name.Split(" ")[0]),
                1);
        Console.WriteLine("------------ Listing Lazy yield Result --------------------");
        Console.ReadLine();
        foreach(object l in names)
            Console.WriteLine(l);
    }
}



