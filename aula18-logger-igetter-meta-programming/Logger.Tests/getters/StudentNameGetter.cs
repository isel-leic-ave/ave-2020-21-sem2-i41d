public class StudentNameGetter : GetterBase 
{

    public StudentNameGetter() :  base("name") {
    }

    public override object GetValue(object target) {
        return ((Student)target).name;
    }
}
