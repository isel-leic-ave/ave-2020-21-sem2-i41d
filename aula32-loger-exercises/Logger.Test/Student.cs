public class Student {
    [ToLog] public readonly int nr;
    [ToLog] public readonly string name;
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