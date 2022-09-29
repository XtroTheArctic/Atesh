// ReSharper disable once CheckNamespace

namespace System.Runtime.CompilerServices;

// .NET 5 and later versions already provides this attribute but .NET Standard 2.1 doesn't, which is the version we have to use for Unity.
// By just having this attribute implemented, .NET framework is able to call a method with this attribute after loading its module.
// We learned this from Gael the maker of PostSharp and Metalama.
//todo: If Unity supports .NET 6 or newer versions, then we can get rid of this custom class while upgrading this project from .NET Standard 2.1 to the new .NET platform.
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
class ModuleInitializerAttribute : Attribute
{
}