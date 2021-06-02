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

public class LogFormatterFirstName : IFormatter
{
    /// <summary>
    /// The argument val is a Fullname that we want to extract the first word.
    /// </summary>
    public object Format(object val)
    {
        string name = (string) val;
        return name.Split(' ')[0];
    }
}