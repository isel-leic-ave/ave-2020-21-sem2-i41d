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
        AppQueries7.Run();
    }

}