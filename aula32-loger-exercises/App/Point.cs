using System;

public struct Point{
    [ToLog("Blue and White")] public readonly int x;
    [ToLog] public readonly int y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    [ToLog(typeof(LogFormatterTruncate), 3)] public double GetModule() {
            return System.Math.Sqrt(x*x + y*y);
    }
    
}

class LogFormatterTruncate : IFormatter
{
    readonly int decimals;

    public LogFormatterTruncate(int decimals)
    {
        this.decimals = decimals;
    }

    public LogFormatterTruncate()
    {
        this.decimals = 1;
    }

    public object Format(object val)
    {
        return Math.Round((double) val, decimals);
    }
}