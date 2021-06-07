using System;
using System.Collections;
using System.Text;
using System.IO;


class App {

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
     
    static IEnumerable ConvertToStudents(IEnumerable lines) {
        return null;
    }
    
    static IEnumerable ConvertToFirstName(IEnumerable stds) {
        return "";
    }
    
    static IEnumerable FilterWithNumberGreaterThan(IEnumerable stds, int nr) {
        return null;
    }
    
    static IEnumerable FilterNameStartsWith(IEnumerable stds, String prefix) {
        return null;
    }
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Main()
    {
        IEnumerable names = 
            ConvertToFirstName(                  // Seq<String>
                FilterNameStartsWith(            // Seq<Student>
                    FilterWithNumberGreaterThan( // Seq<Student>
                        ConvertToStudents(       // Seq<Student> 
                            Lines("isel-AVE-2021.txt")),  // Seq<String>
                        47000), 
                    "D")
                );
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
}
