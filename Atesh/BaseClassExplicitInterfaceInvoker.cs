// BaseClassExplicitInterfaceInvoker originally courtesy of Roland Pihlakas:
// https://stackoverflow.com/a/12044000/2595856
//
// Modified by Onur "Xtro" Er and included in Atesh Framework / October 2017.

using System.Reflection;

namespace Atesh;

public class BaseClassExplicitInterfaceInvoker<T>
{
    readonly Dictionary<string, MethodInfo> MethodsByMethodName = [];

    MethodInfo FindMethod(string MethodName)
    {
        if (MethodsByMethodName.TryGetValue(MethodName, out var Result)) return Result;

        var BaseType = typeof(T);

        while (Result == null)
        {
            if ((BaseType = BaseType.BaseType) == typeof(object)) break;

            var Methods = BaseType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            Result = Methods.FirstOrDefault(X => X.IsFinal && X.IsPrivate && (X.Name == MethodName || X.Name.EndsWith("." + MethodName, StringComparison.Ordinal)));
        }

        if (Result is { }) MethodsByMethodName.Add(MethodName, Result);

        return Result;
    }

    public void Invoke(T Object, string MethodName, params object[] Parameters) => FindMethod(MethodName).Invoke(Object, Parameters);
    public TReturn Invoke<TReturn>(T Object, string MethodName, params object[] Parameters) => (TReturn)FindMethod(MethodName).Invoke(Object, Parameters);
}