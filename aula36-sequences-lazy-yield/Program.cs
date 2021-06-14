using System;
using System.Collections;

public class Program {


    static IEnumerable Numbers() {

        Console.WriteLine("Iteration started...");

        yield return 11;

        yield return 17;

        yield return 23;
    }


    static void Main() {
        // AppQueries4.Run();
        // AppQueries5.Run();
        // AppQueries6.Run();
        IEnumerator nrs = Numbers().GetEnumerator();
        Console.WriteLine(nrs.MoveNext()); // true
        Console.WriteLine(nrs.Current);    // 11
        Console.WriteLine(nrs.Current);    // 11
        Console.WriteLine(nrs.MoveNext()); // true
        Console.WriteLine(nrs.Current);    // 17
        Console.WriteLine(nrs.MoveNext()); // true
        Console.WriteLine(nrs.Current);    // 23
        Console.WriteLine(nrs.MoveNext()); // false;
        Console.WriteLine(nrs.Current);    // Exception

    }

}