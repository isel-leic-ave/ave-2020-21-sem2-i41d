public class StudentNrGetter : AbstractGetter
{
    public StudentNrGetter() : base("nr")
    {
    }

    public override object GetValue(object target)
    {
        Student st = (Student) target;
        return st.nr;
    }
}