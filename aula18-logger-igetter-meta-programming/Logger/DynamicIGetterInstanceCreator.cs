using System;
using System.Reflection;
using System.Reflection.Emit;

public class DynamicIGetterInstanceCreator
{
    AssemblyName assemblyName = new AssemblyName("DynamicIGetters");
    private AssemblyBuilder assemblyBuilder;
    private ModuleBuilder moduleBuilder;

    public DynamicIGetterInstanceCreator()
    {
        assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
            assemblyName,
            AssemblyBuilderAccess.RunAndSave);

        // For a single-module assembly, the module name is usually
        // the assembly name plus an extension.
        moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");

    }

    ~DynamicIGetterInstanceCreator()
    {
        Console.WriteLine("Creating " + assemblyName);
        assemblyBuilder.Save(assemblyName + ".dll");
    }

    /*
     * 1. Create a new implementation of IGetter for member memberName in domain type targetType
     * 2. Creates an instance of that type created in 1.
     */
    public IGetter CreateIGetterFor(Type targetType, MemberInfo member)
    {
        if(member.MemberType != MemberTypes.Field)
            throw new InvalidOperationException("LogDynamic does not support other kind of members beyond Fields like " + member.Name);
        Type getterType = BuildDynamicGetterTypeFor(targetType, (FieldInfo) member);
        IGetter getter = (IGetter)Activator.CreateInstance(getterType, new object[] {  });
        return getter;
    }


    private Type BuildDynamicGetterTypeFor(Type targetType, FieldInfo field) {
        string typeName = targetType.Name + field.Name + "Getter";
        TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public, typeof(GetterBase));

        AddConstructor(typeBuilder, field);
        AddGetValue(typeBuilder, targetType, field);

        return typeBuilder.CreateType();
    }


    private void AddConstructor(TypeBuilder typeBuilder, FieldInfo field) {
        Type[] parameterTypes = { };
        ConstructorBuilder constr = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);

        ConstructorInfo baseConstructor = typeof(GetterBase).GetConstructor(new Type[] { typeof(string) });

        ILGenerator ctorIl = constr.GetILGenerator();

        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Ldstr, field.Name);
        ctorIl.Emit(OpCodes.Call, baseConstructor);
        ctorIl.Emit(OpCodes.Ret);
    }

    private void AddGetValue(TypeBuilder typeBuilder, Type targetType,  FieldInfo field) {
        MethodBuilder mb = typeBuilder.DefineMethod(
            "GetValue", 
            MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, 
            typeof(object), 
            new Type[] { typeof(object) }
        );

        ILGenerator ilGen = mb.GetILGenerator();
        ilGen.Emit(OpCodes.Ldarg_1);
        ilGen.Emit(OpCodes.Castclass, targetType);
        ilGen.Emit(OpCodes.Ldfld, field);
        if(field.FieldType.IsPrimitive) {
            ilGen.Emit(OpCodes.Box, field.FieldType);
        }
        ilGen.Emit(OpCodes.Ret);
    }
}

