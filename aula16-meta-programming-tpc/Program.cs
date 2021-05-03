using System;
using System.Reflection;
using System.Reflection.Emit;

namespace aula16_meta_programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Type dynType = BuildDynamicAssemblyAndType();
            // 
            // <=> obj = new MyDynamicType(7);
            // 
            object obj = Activator.CreateInstance(dynType, new object[]{7}); 
            // 
            // <=> obj.MyMethod(5);
            // 
            object res = dynType.GetMethod("MyMethod", new Type[]{typeof(int)}).Invoke(obj, new object[]{5});
            Console.WriteLine("new MyDynamicType(7).MyMethod(5) = " + res);
            //
            // <=> obj.MyMethod(new MyDynamicType(9)) ----> 63
            // 
            object other = Activator.CreateInstance(dynType, new object[]{9}); 
            res = dynType
                    .GetMethod("MyMethod", new Type[]{dynType})
                    .Invoke(obj, new object[]{other});
            Console.WriteLine("new MyDynamicType(7).MyMethod(new MyDynamicType(9)) = " + res);
        }
        private static Type BuildDynamicAssemblyAndType()
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(
                aName,
                AssemblyBuilderAccess.Run);

            // For a single-module assembly, the module name is usually
            // the assembly name plus an extension.
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name);

            return BuildType(mb);
        }

        private static Type BuildType(ModuleBuilder mb)
        {
            // Create a new type MyDynamicType
            TypeBuilder tb = mb.DefineType("MyDynamicType",TypeAttributes.Public);

            // Add a private field of type int (Int32).
            FieldBuilder fbNumber = tb.DefineField("m_number", typeof(int), FieldAttributes.Private);

            AddConstructor(tb, fbNumber);
            AddMyMethod(tb, fbNumber);

            // Finish the type.
            Type t = tb.CreateType();
            return t;
        }

        private static void AddMyMethod(TypeBuilder tb, FieldBuilder fbNumber)
        {
            // Define a method that accepts an integer argument and returns
            // the product of that integer and the private field m_number. This
            // time, the array of parameter types is created on the fly.
            MethodBuilder meth = tb.DefineMethod(
                "MyMethod",
                MethodAttributes.Public,
                typeof(int),
                new Type[] { typeof(int) });

            ILGenerator methIL = meth.GetILGenerator();
            // To retrieve the private instance field, load the instance it
            // belongs to (argument zero). After loading the field, load the
            // argument one and then multiply. Return from the method with
            // the return value (the product of the two numbers) on the
            // execution stack.
            methIL.Emit(OpCodes.Ldarg_0);         // push this
            methIL.Emit(OpCodes.Ldfld, fbNumber); // push this.m_number
            methIL.Emit(OpCodes.Ldarg_1);         // push arg
            methIL.Emit(OpCodes.Mul);             // this.m_number * arg;
            methIL.Emit(OpCodes.Ret);
        }

        private static void AddConstructor(TypeBuilder tb, FieldInfo fbNumber)
        {
            // Define a constructor that takes an integer argument and
            // stores it in the private field.
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                parameterTypes);
            ConstructorInfo baseCtor = typeof(object).GetConstructor(Type.EmptyTypes);
            ILGenerator ctor1IL = ctor1.GetILGenerator();
            ctor1IL.Emit(OpCodes.Ldarg_0);         // push this
            ctor1IL.Emit(OpCodes.Call, baseCtor);  // Call base construtor => Object constructor.
            ctor1IL.Emit(OpCodes.Ldarg_0);         // push this
            ctor1IL.Emit(OpCodes.Ldarg_1);         // push the int argument
            ctor1IL.Emit(OpCodes.Stfld, fbNumber); // store field
            ctor1IL.Emit(OpCodes.Ret);
        }
    }
}
