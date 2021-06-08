public class StudentNameGetter : AbstractGetter
{
    public StudentNameGetter() : base("name")
    {
    }

    public override object GetValue(object target)
    {
        Student st = (Student) target;
        return st.name;
    }
}