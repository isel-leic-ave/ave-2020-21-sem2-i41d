public class StudentNumberGetter : GetterBase { 
   public StudentNumberGetter() : base("nr") { 
   }

   public override object GetValue(object target) {
       return ((Student)target).nr;
   }
   
}