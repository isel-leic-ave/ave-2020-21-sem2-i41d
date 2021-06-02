using System;

namespace Logger
{
        
    class ConsolePrinter : IPrinter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }

}
