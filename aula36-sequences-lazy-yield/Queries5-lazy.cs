using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

class AppQueries5 {

    static IEnumerable Lines(string path)
    {
        string line;
        IList res = new ArrayList();
        using(StreamReader file = new StreamReader(path)) // <=> try-with resources do Java >= 7
        {
            while ((line = file.ReadLine()) != null)
            {
                res.Add(line);
            }
        }
        return res;
    }
     
    static IEnumerable Convert(IEnumerable src, FunctionDelegate mapper) {
        return new ConvertIEnumerable(src, mapper);
    }
    
    static IEnumerable Filter(IEnumerable src, PredicateDelegate pred) {
        return new FilterIEnumerable(src, pred);
    }

    static IEnumerable Take(IEnumerable src, int nr) {
        return new TakeIEnumerable(src, nr);
    }

    static IEnumerable Distinct(IEnumerable src) {
        HashSet<object> set = new HashSet<object>();
        foreach(object o in src)
            set.Add(o);

        return set;
    }
    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    public static void Run()
    {
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
        Console.WriteLine("------------ Listing Lazy Result --------------------");
        Console.ReadLine();
        foreach(object l in names)
            Console.WriteLine(l);
    }
}



