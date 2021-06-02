using System;

public class Point{
    [ToLog] public readonly int x;
    [ToLog] public readonly int y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    [ToLog(typeof(LogFormatterTruncate), "1")]public double GetModule() {
    // [ToLog(typeof(LogFormatterTruncate))]public double GetModule() {
            return System.Math.Sqrt(x*x + y*y);
    }

     public Point Add(Point other) {
            return new Point(x + other.x, y + other.y);
    }
    
}

public class LogFormatterTruncate : IFormatter {
    private readonly int decimals;
    public LogFormatterTruncate(int decimals) {
        this.decimals = decimals;
    }
    public LogFormatterTruncate() {
        this.decimals = 2;
    }
    public object Format(object val) {
        double nr = (double) val;
        return Math.Round(nr, decimals);
    }
}