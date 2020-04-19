using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Atesh
{
    public static class TypeExtensions
    {
        static readonly Dictionary<Type, IReadOnlyCollection<MemberInfo>> FieldsAndProperties = new Dictionary<Type, IReadOnlyCollection<MemberInfo>>();

        public static string NameAndNameSpace(this Type This)
        {
            var FullName = This.FullName;
            var Result = FullName.Substring(FullName.LastIndexOf('.') + 1);
            if (!string.IsNullOrWhiteSpace(This.Namespace)) Result = $"{Result} ({This.Namespace})";
             
            return Result;
        }

        public static bool IsStruct(this Type This) => This.IsValueType && !This.IsPrimitive && !This.IsEnum;

        public static IEnumerable<PropertyDescriptor> GetBrowsableProperties(this Type This) => TypeDescriptor.GetProperties(This, new Attribute[] { BrowsableAttribute.Yes }).Cast<PropertyDescriptor>();
        public static IEnumerable<PropertyDescriptor> GetSerializableProperties(this Type This) => TypeDescriptor.GetProperties(This).Cast<PropertyDescriptor>().Where(X => !X.IsReadOnly && X.SerializationVisibility != DesignerSerializationVisibility.Hidden);

        public static IReadOnlyCollection<MemberInfo> GetFieldsAndProperties(this Type This)
        {
            if (FieldsAndProperties.ContainsKey(This)) return FieldsAndProperties[This];

            var Result = new List<MemberInfo>();
            Result.AddRange(This.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Where(X => X.MemberType == MemberTypes.Field || X.MemberType == MemberTypes.Property));

            return FieldsAndProperties[This] = Result.AsReadOnly();
        }
    }
}