using System.ComponentModel;
using System.Reflection;

namespace Atesh;

public static class TypeExtensions
{
    static readonly Dictionary<Type, IReadOnlyCollection<MemberInfo>> FieldsAndPropertiesCollectionByType = [];

    public static string NameAndNameSpace(this Type This)
    {
        var FullName = This.FullName;
        var Result = FullName[(FullName.LastIndexOf('.') + 1)..];
        if (This.Namespace.HasValue()) Result = $"{Result} ({This.Namespace})";
             
        return Result;
    }

    public static bool IsStruct(this Type This) => This.IsValueType && !This.IsPrimitive && !This.IsEnum;

    public static IEnumerable<PropertyDescriptor> GetBrowsableProperties(this Type This) => TypeDescriptor.GetProperties(This, [BrowsableAttribute.Yes]).Cast<PropertyDescriptor>();
    public static IEnumerable<PropertyDescriptor> GetSerializableProperties(this Type This) => TypeDescriptor.GetProperties(This).Cast<PropertyDescriptor>().Where(X => !X.IsReadOnly && X.SerializationVisibility != DesignerSerializationVisibility.Hidden);

    public static IReadOnlyCollection<MemberInfo> GetFieldsAndProperties(this Type This)
    {
        if (FieldsAndPropertiesCollectionByType.TryGetValue(This, out var FieldsAndProperties)) return FieldsAndProperties;

        var Result = new List<MemberInfo>();

        // GetMembers doesn't return inherited private fields so, we loop for base classes with DeclaredOnly flag.
        var Type = This;

        while (Type != typeof(object))
        {
            Result.AddRange(Type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Where(X => X.MemberType is MemberTypes.Field or MemberTypes.Property));

            Type = Type.BaseType;
        }

        return FieldsAndPropertiesCollectionByType[This] = Result.AsReadOnly();
    }
}