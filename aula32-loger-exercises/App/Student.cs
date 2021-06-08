public class Student {
    [ToLog] public readonly int nr;
    [ToLog(typeof(LogFormatterFirstName))] public readonly string name;
    public readonly int group;
    public readonly string githubId;

    public Student(int nr, string name, int group, string githubId)
    {
        this.nr = nr;
        this.name = name;
        this.group = group;
        this.githubId = githubId;
    }
}

class LogFormatterFirstName : IFormatter{

    public object Format (object name) {
        return ((string)name).Split(' ')[0];
    }
}