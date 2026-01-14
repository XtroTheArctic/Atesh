using System.ComponentModel;
using System.Reflection;

namespace Atesh;

public static class TypeExtensions
{
    static readonly Dictionary<Type, IReadOnlyCollection<MemberInfo>> FieldsAndPropertiesOfTypes = [];

    extension(Type This)
    {
        public bool IsStruct => This.IsValueType && !This.IsPrimitive && !This.IsEnum;

        public string NameAndNameSpace
        {
            get
            {
                var FullName = This.FullName;
                var Result = FullName[(FullName.LastIndexOf('.') + 1)..];
                if (This.Namespace.HasValue) Result = $"{Result} ({This.Namespace})";

                return Result;
            }
        }

        public IEnumerable<PropertyDescriptor> GetBrowsableProperties() => TypeDescriptor.GetProperties(This, [BrowsableAttribute.Yes]).Cast<PropertyDescriptor>();
        public IEnumerable<PropertyDescriptor> GetSerializableProperties() => TypeDescriptor.GetProperties(This).Cast<PropertyDescriptor>().Where(X => !X.IsReadOnly && X.SerializationVisibility != DesignerSerializationVisibility.Hidden);

        public IReadOnlyCollection<MemberInfo> GetFieldsAndProperties()
        {
            if (FieldsAndPropertiesOfTypes.TryGetValue(This, out var Value)) return Value;

            var Result = new List<MemberInfo>();

            // GetMembers doesn't return inherited private fields so, we loop for base classes with DeclaredOnly flag.
            var Type = This;

            while (Type != typeof(object))
            {
                Result.AddRange(Type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Where(X => X.MemberType is MemberTypes.Field or MemberTypes.Property));

                Type = Type.BaseType;
            }

            return FieldsAndPropertiesOfTypes[This] = Result;
        }
    }
}