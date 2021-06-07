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
        IList res = new ArrayList();
        foreach (object o in lines) {
            res.Add(Student.Parse((string) o));
        }
        return res;
    }
    
    static IEnumerable ConvertToFirstName(IEnumerable stds) {
        IList res = new ArrayList();
        foreach (object o in stds) {
            res.Add(((Student)o).Name.Split(" ")[0]);
        }
        return res;
    }
    
    static IEnumerable FilterWithNumberGreaterThan(IEnumerable stds, int nr) {
        IList res = new ArrayList();
        foreach (object o in stds) {
            Student std = (Student)o;
            if (std.Number > nr) res.Add(o);
        }
        return res;
    }
    
    static IEnumerable FilterNameStartsWith(IEnumerable stds, String prefix) {
        IList res = new ArrayList();
        foreach (object o in stds) {
            if (((Student)o).Name.StartsWith(prefix)) res.Add(o);
        }
        return res;
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
