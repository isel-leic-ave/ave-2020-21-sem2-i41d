using System.Text;

public class BufferPrinter : IPrinter
{
    public readonly StringBuilder buffer = new StringBuilder();
    public void Print(string output)
    {
        buffer.Append(output);
    }
}