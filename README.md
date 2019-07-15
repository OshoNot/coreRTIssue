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
    Compiles but generates Exception when running:
        ```
            database_1   | running bootstrap script ... ok
            prototype_1  | Unhandled Exception: System.TypeInitializationException: A type initializer threw an exception. To determine which type, inspect the InnerException's StackTrace property.
            prototype_1  |  ---> EETypeRva:0x05B6B9C8(System.Reflection.MissingRuntimeArtifactException): MakeGenericMethod() cannot create this generic method instantiation because the instantiation was not metadata-enabled: 'Microsoft.FSharp.Core.PrintfImpl.Specializations<Microsoft.FSharp.Core.Unit,System.String,System.String>.FinalFastEnd5<System.String,System.String,System.String,System.Int32,System.String>(System.String,Microsoft.FSharp.Core.FSharpFunc<System.String,System.String>,System.String,Microsoft.FSharp.Core.FSharpFunc<System.String,System.String>,System.String,Microsoft.FSharp.Core.FSharpFunc<System.String,System.String>,System.String,Microsoft.FSharp.Core.FSharpFunc<System.Int32,System.String>,System.String,Microsoft.FSharp.Core.FSharpFunc<System.String,System.String>)' For more information, please visit http://go.microsoft.com/fwlink/?LinkID=616868
            prototype_1  |    at Internal.Reflection.Core.Execution.ExecutionEnvironment.GetMethodInvoker(RuntimeTypeInfo, QMethodDefinition, RuntimeTypeInfo[], MemberInfo) + 0x165
            prototype_1  |    at System.Reflection.Runtime.MethodInfos.NativeFormat.NativeFormatMethodCommon.GetUncachedMethodInvoker(RuntimeTypeInfo[], MemberInfo) + 0x3f
            prototype_1  |    at System.Reflection.Runtime.MethodInfos.RuntimeMethodInfo.get_MethodInvoker() + 0xab
            prototype_1  |    at System.Reflection.Runtime.MethodInfos.RuntimeNamedMethodInfo`1.MakeGenericMethod(Type[]) + 0x114
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder`3.buildPlainFinal(Object[], Type[]) + 0x243
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder`3.parseFromFormatSpecifier(String, String, Type, Int32) + 0x517
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder`3.parseFromFormatSpecifier(String, String, Type, Int32) + 0x1ed
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder`3.parseFormatString(String, Type) + 0xb4
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.PrintfBuilder`3.Build[T](String) + 0x42
            prototype_1  |    at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey, Func`2) + 0x80
            prototype_1  |    at Microsoft.FSharp.Core.PrintfImpl.Cache`4.Get(PrintfFormat`4) + 0x6b
            prototype_1  |    at Microsoft.FSharp.Core.PrintfModule.PrintFormatToStringThen[T](PrintfFormat`4) + 0x19
            prototype_1  |    at Npgsql.FSharp.SqlModule.str(SqlModule.ConnectionStringBuilder) + 0x3d
            prototype_1  |    at <StartupCode$DbPrototype>.$Program..cctor() + 0x1ca
            prototype_1  |    at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0xd5
            prototype_1  |    --- End of inner exception stack trace ---
            prototype_1  |    at System.Runtime.CompilerServices.ClassConstructorRunner.EnsureClassConstructorRun(StaticClassConstructionContext*) + 0x198
            prototype_1  |    at System.Runtime.CompilerServices.ClassConstructorRunner.CheckStaticClassConstructionReturnNonGCStaticBase(StaticClassConstructionContext*, IntPtr) + 0x9
            prototype_1  |    at Program.main(String[]) + 0xd
            prototype_1  |    at DbPrototype!<BaseAddress>+0x1896b6d
            prototype_1  | Aborted
            database_1   | performing post-bootstrap initialization ... ok
        ```
        The above error is discussed [here](https://github.com/dotnet/corert/issues/7605#issuecomment-510539851)
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