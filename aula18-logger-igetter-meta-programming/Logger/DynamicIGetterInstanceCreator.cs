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

    public IGetter CreateIGetterFor(Type targetType, string memberName)
    {
        Type getterType = BuildDynamicGetterTypeFor(targetType, memberName);
        IGetter getter = (IGetter)Activator.CreateInstance(getterType, new object[] {  });
        return getter;
    }


    private Type BuildDynamicGetterTypeFor(Type targetType, string memberName) {
        string typeName = targetType.Name + memberName + "Getter";
        TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public, typeof(GetterBase));

        AddConstructor(typeBuilder, memberName);
        AddGetValue(typeBuilder, targetType, memberName);

        return typeBuilder.CreateType();
    }


    private void AddConstructor(TypeBuilder typeBuilder, string memberName) {
        Type[] parameterTypes = { };
        ConstructorBuilder constr = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, parameterTypes);

        ConstructorInfo baseConstructor = typeof(GetterBase).GetConstructor(new Type[] { typeof(string) });

        ILGenerator ctorIl = constr.GetILGenerator();

        ctorIl.Emit(OpCodes.Ldarg_0);
        ctorIl.Emit(OpCodes.Ldstr, memberName);
        ctorIl.Emit(OpCodes.Call, baseConstructor);
        ctorIl.Emit(OpCodes.Ret);
    }

    private void AddGetValue(TypeBuilder typeBuilder, Type targetType,  string memberName) {
        MethodBuilder mb = typeBuilder.DefineMethod(
            "GetValue", 
            MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, 
            typeof(object), 
            new Type[] { typeof(object) }
        );
        FieldInfo targetField = targetType.GetField(memberName);

        ILGenerator ilGen = mb.GetILGenerator();
        ilGen.Emit(OpCodes.Ldarg_1);
        ilGen.Emit(OpCodes.Castclass, targetType);
        ilGen.Emit(OpCodes.Ldfld, targetField);
        if(targetField.FieldType.IsPrimitive) {
            ilGen.Emit(OpCodes.Box, targetField.FieldType);
        }
        ilGen.Emit(OpCodes.Ret);
    }
}

