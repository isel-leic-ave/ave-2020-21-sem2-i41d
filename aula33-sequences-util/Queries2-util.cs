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
     
    static IEnumerable Convert(IEnumerable src, Function mapper) {
        IList res = new ArrayList();
        foreach (object o in src) {
            res.Add(mapper.Invoke(o));
        }
        return res;
    }
    
    static IEnumerable Filter(IEnumerable stds, Predicate pred) {
        IList res = new ArrayList();
        foreach (object o in stds) {
            if (pred.Invoke(o)) 
                res.Add(o);
        }
        return res;
    }
    
    
    /**
     * Representa o domínio e o cliente App
     */
 
    static void Main()
    {
        IEnumerable names = 
                Convert(              // Seq<String>
                    Filter(           // Seq<Student>
                        Filter(       // Seq<Student>
                            Convert(  // Seq<Student> 
                                Lines("isel-AVE-2021.txt"),  // Seq<String>
                                new ToStudent()),
                            new FilterNumberGreaterThan(47000)),
                        new FilterNameStartsWith("D")),
                    new ToFirstName());
    
        foreach(object l in names)
            Console.WriteLine(l);
    }
}
class ToStudent : Function
{
    public object Invoke(object o)
    {
        return Student.Parse((string) o);
    }
}
class ToFirstName : Function
{
    public object Invoke(object o)
    {
        return ((Student) o).Name.Split(" ")[0];
    }
}
class FilterNumberGreaterThan : Predicate
{
    private readonly int nr;

    public FilterNumberGreaterThan(int v)
    {
        this.nr = v;
    }

    public bool Invoke(object o)
    {
        return ((Student) o).Number > nr;
    }
}
class FilterNameStartsWith : Predicate
{
    private readonly string prefix;

    public FilterNameStartsWith(string v)
    {
        this.prefix = v;
    }

    public bool Invoke(object o)
    {
        return ((Student) o).Name.StartsWith(prefix);
    }
}
