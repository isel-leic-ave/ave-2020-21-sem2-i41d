public class Point{
    public readonly int x;
    public readonly int y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public double GetModule() {
            return System.Math.Sqrt(x*x + y*y);
    }

     public Point Add(Point other) {
            return new Point(x + other.x, y + other.y);
    }
    
}
