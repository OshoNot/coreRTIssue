# Purpose
This Repo is intended to test coreRT compilation issues ([#7605](https://github.com/dotnet/corert/issues/7605)) with Npgsql. It executes a simple SQL command (CREATE table) in 
a PostgreSQL DB container.

# Requirements
- Docker && Docker Compose

# Stack
- Docker
- .Net Core 2.2
- Npgsql 4.0.7
- Ngpsql.Fsharp 1.10.0
- F#/C#
- Postgres 10

# Running
```
cd REPO_DIRECTORY
docker-compose up
```

# Current State
 - Linux
    Compiles but generates Exception when running. The error below is discussed [here](https://github.com/dotnet/corert/issues/7605#issuecomment-510539851).
        ```
            Internal.Reflection.Core.Execution.ExecutionEnvironment.GetMethodInvoker(RuntimeTypeInfo, QMethodDefinition, RuntimeTypeInfo[], MemberInfo) + 0x165
            System.Reflection.Runtime.MethodInfos.NativeFormat.NativeFormatMethodCommon.GetUncachedMethodInvoker(RuntimeTypeInfo[], MemberInfo) + 0x3f
            System.Reflection.Runtime.MethodInfos.RuntimeMethodInfo.get_MethodInvoker() + 0xab
            System.Reflection.Runtime.MethodInfos.RuntimeNamedMethodInfo1.MakeGenericMethod(Type[]) + 0x114
            Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder3.buildPlainFinal(Object[], Type[]) + 0x243
            Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder3.parseFromFormatSpecifier(String, String, Type, Int32) + 0x517
            Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder3.parseFromFormatSpecifier(String, String, Type, Int32) + 0x1ed
            Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder3.parseFormatString(String, Type) + 0xb4
            Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder3.Build[T](String) + 0x42
            System.Collections.Concurrent.ConcurrentDictionary2.GetOrAdd(TKey, Func2) + 0x80
            Microsoft.FSharp.Core.PrintfImpl.Cache4.Get(PrintfFormat4) + 0x6b
            Microsoft.FSharp.Core.PrintfModule.PrintFormatToStringThen[T](PrintfFormat4) + 0x19
            Npgsql.FSharp.SqlModule.str(SqlModule.ConnectionStringBuilder) + 0x3d
            <StartupCode$DbPrototype>.$Program..cctor() + 0x1ca
            System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0xd5
            ---- End of inner exception stack trace ---
            System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0x198
            System.Runtime.CompilerServices.ClassConstructorRunner.CheckStaticClassConstructionReturnNonGCStaticBase(StaticClassConstructionContext*, IntPtr) + 0x9
            Program.main(String[]) + 0xd
            DbPrototype!<BaseAddress>+0x1896b6d
        ```
 - MacOS
    Fail compilation with error: 
    ```
        Task "Exec"
         "/root/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/1.0.0-alpha-27910-01/tools/ilc" @"obj/Release/netcoreapp2.1/linux-x64/native/DbPrototype.ilc.rsp"
		         Killed
        1:7>/root/.nuget/packages/microsoft.dotnet.ilcompiler/1.0.0-alpha-27910-01/build/Microsoft.NETCore.Native.targets(249,5): error MSB3073: The command ""/root/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/1.0.0-alpha-27910-01/tools/ilc" @"obj/Release/netcoreapp2.1/linux-x64/native/DbPrototype.ilc.rsp"" exited with code 137. [/home/app/DbPrototype.fsproj]
        Done executing task "Exec" -- FAILED.
        1:7>Done building target "IlcCompile" in project "DbPrototype.fsproj" -- FAILED.
        1:7>Done Building Project "/home/app/DbPrototype.fsproj" (Publish target(s)) -- FAILED.
    ```

# Related Issues
Other issues regarding CoreRT usage with the project stack could be found in these links:
- [Npgsql](https://github.com/dotnet/corert/issues?utf8=✓&q=is%3Aissue+npgsql)
- [F#](https://github.com/dotnet/corert/issues/2057)

# C# implementation
A C# version and its instructions could be found inside the [Helloworld](https://github.com/OshoNot/coreRTissue/tree/master/HelloWorld) directory. 