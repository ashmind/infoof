using System.Reflection;
using System.Runtime.InteropServices;

using InfoOf.Properties;

[assembly: AssemblyTitle("InfoOf")]
[assembly: AssemblyDescription(@"
    A small set of methods that help getting MemberInfo using lambda expressions.  
    Example: Info.PropertyOf<MyClass>(c => c.MyProperty);
")]
[assembly: AssemblyCompany("Andrey Shchekin")]
[assembly: AssemblyProduct("InfoOf")]
[assembly: AssemblyCopyright("Copyright © Andrey Shchekin 2015")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b2bcfed3-1ac3-48db-bf8a-aa22b3133c57")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.VersionString)]
[assembly: AssemblyFileVersion(AssemblyInfo.VersionString)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.VersionString)]

namespace InfoOf.Properties {
    internal static class AssemblyInfo {
        public const string VersionString = "1.0.0";
    }
}