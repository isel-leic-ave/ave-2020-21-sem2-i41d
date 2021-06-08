using System;
using System.Reflection;
using System.Reflection.Emit;

public class DynamicGetterBuider 
{
    private readonly AssemblyBuilder ab;
    private readonly ModuleBuilder mb;
    private readonly Type domain;
    private readonly AssemblyName aName;

    public DynamicGetterBuider(Type domain)
    {
        this.domain = domain;
        aName = new AssemblyName(domain.Name + "Getters");
        ab = AssemblyBuilder.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);

        // For a single-module assembly, the module name is usually
        // the assembly name plus an extension.
        mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
    }

    public void SaveModule()
    {
        ab.Save(aName.Name + ".dll");
    }

    public Type GenerateGetterFor(MemberInfo m) {
        if(m.MemberType == MemberTypes.Field)
            return GenerateGetterFor(m as FieldInfo);
        else
            throw new InvalidOperationException("There is no dynamic getter support for member of type " + m.MemberType);
    }

    public Type GenerateGetterFor(FieldInfo f) {
        // 1. Define the type
        TypeBuilder getterType = mb.DefineType(
            domain.Name + f.Name + "Getter", TypeAttributes.Public, typeof(AbstractGetter));

        // 2. Define the paraneterless constructor
        BuildConstructor(getterType, f);

        // 3. Define the method GetValue
        BuildGetValue(getterType, f);

        // Finish type
        return getterType.CreateType();
    }

    private void BuildGetValue(TypeBuilder getterType, FieldInfo f)
    {
        MethodBuilder getValBuilder = getterType.DefineMethod(
            "GetValue", 
            MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig,
            typeof(object),
            new Type[] {typeof(object)});

        ILGenerator il = getValBuilder.GetILGenerator();

        il.Emit(OpCodes.Ldarg_1);             // ldarg.1
        il.Emit(OpCodes.Castclass, domain);   // castclass  Student
        il.Emit(OpCodes.Ldfld, f);            // ldfld      string Student::name
        if(f.FieldType.IsPrimitive)
            il.Emit(OpCodes.Box, f.FieldType); // box 
        il.Emit(OpCodes.Ret);                 // ret

    }

    private void BuildConstructor(TypeBuilder getterType, FieldInfo f)
    {
        ConstructorBuilder ctor = getterType.DefineConstructor(
            MethodAttributes.Public,
             CallingConventions.Standard,
             Type.EmptyTypes); // <=> new Type[0]

        ILGenerator il = ctor.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);      // ldarg.0
        il.Emit(OpCodes.Ldstr, f.Name);// ldstr      "name"
        il.Emit(
            OpCodes.Call,              // call AbstractGetter::.ctor(string)
            typeof(AbstractGetter).GetConstructor(new Type[]{typeof(string)}));
        il.Emit(OpCodes.Ret);
    }
}