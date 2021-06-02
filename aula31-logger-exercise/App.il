
//  Microsoft (R) .NET IL Disassembler.  Version 5.0.0



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern Logger
{
  .ver 1:0:0:0
}
.assembly App
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 38 01 00 54   // ,Version=v4.8..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 12 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 2E 38 )                      // ework 4.8
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 03 41 70 70 00 00 )                         // ...App..
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 03 41 70 70 00 00 )                         // ...App..
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 03 41 70 70 00 00 )                         // ...App..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module App.exe
// MVID: {1d96c824-50fa-4625-a38d-8ddec1170cce}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x000000010A4A4000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Account
       extends [mscorlib]System.Object
{
  .field public static initonly int32 CODE
  .field public int64 balance
  .custom instance void [Logger]ToLogAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int64 b) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  stfld      int64 Account::balance
    IL_000f:  ret
  } // end of method Account::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  ldc.i4     0x10f6
    IL_0005:  stsfld     int32 Account::CODE
    IL_000a:  ret
  } // end of method Account::.cctor

} // end of class Account

.class public auto ansi beforefieldinit StudentNameGetter
       extends [Logger]GetterBase
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "name"
    IL_0006:  call       instance void [Logger]GetterBase::.ctor(string)
    IL_000d:  ret
  } // end of method StudentNameGetter::.ctor

  .method public hidebysig virtual instance object 
          GetValue(object target) cil managed
  {
    // Code size       17 (0x11)
    .maxstack  1
    .locals init (object V_0)
    IL_0001:  ldarg.1
    IL_0002:  castclass  Student
    IL_0007:  ldfld      string Student::name
    IL_0010:  ret
  } // end of method StudentNameGetter::GetValue

} // end of class StudentNameGetter

.class public auto ansi beforefieldinit StudentNumberGetter
       extends [Logger]GetterBase
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "nr"
    IL_0006:  call       instance void [Logger]GetterBase::.ctor(string)
    IL_000d:  ret
  } // end of method StudentNumberGetter::.ctor

  .method public hidebysig virtual instance object 
          GetValue(object target) cil managed
  {
    // Code size       22 (0x16)
    .maxstack  1
    .locals init (object V_0)
    IL_0001:  ldarg.1
    IL_0002:  castclass  Student
    IL_0007:  ldfld      int32 Student::nr
    IL_000c:  box        [mscorlib]System.Int32
    IL_0015:  ret
  } // end of method StudentNumberGetter::GetValue

} // end of class StudentNumberGetter

.class public auto ansi beforefieldinit Point
       extends [mscorlib]System.Object
{
  .field public initonly int32 x
  .custom instance void [Logger]ToLogAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public initonly int32 y
  .custom instance void [Logger]ToLogAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 x,
                               int32 y) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  stfld      int32 Point::x
    IL_000f:  ldarg.0
    IL_0010:  ldarg.2
    IL_0011:  stfld      int32 Point::y
    IL_0016:  ret
  } // end of method Point::.ctor

  .method public hidebysig instance float64 
          GetModule() cil managed
  {
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (float64 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      int32 Point::x
    IL_0007:  ldarg.0
    IL_0008:  ldfld      int32 Point::x
    IL_000d:  mul
    IL_000e:  ldarg.0
    IL_000f:  ldfld      int32 Point::y
    IL_0014:  ldarg.0
    IL_0015:  ldfld      int32 Point::y
    IL_001a:  mul
    IL_001b:  add
    IL_001c:  conv.r8
    IL_001d:  call       float64 [mscorlib]System.Math::Sqrt(float64)
    IL_0022:  stloc.0
    IL_0023:  br.s       IL_0025

    IL_0025:  ldloc.0
    IL_0026:  ret
  } // end of method Point::GetModule

  .method public hidebysig instance class Point 
          Add(class Point other) cil managed
  {
    // Code size       37 (0x25)
    .maxstack  3
    .locals init (class Point V_0)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      int32 Point::x
    IL_0007:  ldarg.1
    IL_0008:  ldfld      int32 Point::x
    IL_000d:  add
    IL_000e:  ldarg.0
    IL_000f:  ldfld      int32 Point::y
    IL_0014:  ldarg.1
    IL_0015:  ldfld      int32 Point::y
    IL_001a:  add
    IL_001b:  newobj     instance void Point::.ctor(int32,
                                                    int32)
    IL_0020:  stloc.0
    IL_0021:  br.s       IL_0023

    IL_0023:  ldloc.0
    IL_0024:  ret
  } // end of method Point::Add

} // end of class Point

.class public auto ansi beforefieldinit Student
       extends [mscorlib]System.Object
{
  .field public initonly int32 nr
  .custom instance void [Logger]ToLogAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public initonly string name
  .custom instance void [Logger]ToLogAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public initonly int32 group
  .field public initonly string githubId
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 nr,
                               string name,
                               int32 group,
                               string githubId) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  stfld      int32 Student::nr
    IL_000f:  ldarg.0
    IL_0010:  ldarg.2
    IL_0011:  stfld      string Student::name
    IL_0016:  ldarg.0
    IL_0017:  ldarg.3
    IL_0018:  stfld      int32 Student::group
    IL_001d:  ldarg.0
    IL_001e:  ldarg.s    githubId
    IL_0020:  stfld      string Student::githubId
    IL_0025:  ret
  } // end of method Student::.ctor

} // end of class Student

.class private auto ansi beforefieldinit App.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       167 (0xa7)
    .maxstack  4
    .locals init (class Point V_0,
             class Student V_1,
             class Student V_2,
             class Student V_3,
             class Student[] V_4,
             class Account V_5,
             class [Logger]Logger.Log V_6)
    IL_0000:  nop
    IL_0001:  ldc.i4.7
    IL_0002:  ldc.i4.s   9
    IL_0004:  newobj     instance void Point::.ctor(int32,
                                                    int32)
    IL_0009:  stloc.0
    IL_000a:  ldc.i4     0x25a16
    IL_000f:  ldstr      "Ze Manel"
    IL_0014:  ldc.i4     0x147b
    IL_0019:  ldstr      "ze"
    IL_001e:  newobj     instance void Student::.ctor(int32,
                                                      string,
                                                      int32,
                                                      string)
    IL_0023:  stloc.1
    IL_0024:  ldc.i4     0x4f28a
    IL_0029:  ldstr      "Xico"
    IL_002e:  ldc.i4     0x4d2
    IL_0033:  ldstr      "xico"
    IL_0038:  newobj     instance void Student::.ctor(int32,
                                                      string,
                                                      int32,
                                                      string)
    IL_003d:  stloc.2
    IL_003e:  ldc.i4     0xba69b
    IL_0043:  ldstr      "Maria Papoila"
    IL_0048:  ldc.i4     0xddb
    IL_004d:  ldstr      "maria"
    IL_0052:  newobj     instance void Student::.ctor(int32,
                                                      string,
                                                      int32,
                                                      string)
    IL_0057:  stloc.3
    IL_0058:  ldc.i4.3
    IL_0059:  newarr     Student
    IL_005e:  dup
    IL_005f:  ldc.i4.0
    IL_0060:  ldloc.1
    IL_0061:  stelem.ref
    IL_0062:  dup
    IL_0063:  ldc.i4.1
    IL_0064:  ldloc.2
    IL_0065:  stelem.ref
    IL_0066:  dup
    IL_0067:  ldc.i4.2
    IL_0068:  ldloc.3
    IL_0069:  stelem.ref
    IL_006a:  stloc.s    V_4
    IL_006c:  ldc.i4     0x514
    IL_0071:  conv.i8
    IL_0072:  newobj     instance void Account::.ctor(int64)
    IL_0077:  stloc.s    V_5
    IL_0079:  newobj     instance void [Logger]Logger.Log::.ctor()
    IL_007e:  stloc.s    V_6
    IL_0080:  ldloc.s    V_6
    IL_0082:  ldloc.0
    IL_0083:  callvirt   instance void [Logger]Logger.Log::Info(object)
    IL_0088:  nop
    IL_0089:  ldloc.s    V_6
    IL_008b:  ldloc.1
    IL_008c:  callvirt   instance void [Logger]Logger.Log::Info(object)
    IL_0091:  nop
    IL_0092:  ldloc.s    V_6
    IL_0094:  ldloc.s    V_5
    IL_0096:  callvirt   instance void [Logger]Logger.Log::Info(object)
    IL_009b:  nop
    IL_009c:  ldloc.s    V_6
    IL_009e:  ldloc.s    V_4
    IL_00a0:  callvirt   instance void [Logger]Logger.Log::Info(object)
    IL_00a5:  nop
    IL_00a6:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class App.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
