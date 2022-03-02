using System;
using PostSharp.Aspects;
using PostSharp.Reflection;
using PostSharp.Serialization;

namespace Atesh.PostSharp;

[PSerializable]
public class NotNullOrWhiteSpaceAttribute : LocationContractAttribute, ILocationValidationAspect<string>
{
    public Exception ValidateValue(string Value, string LocationName, LocationKind LocationKind, LocationValidationContext Context) => string.IsNullOrWhiteSpace(Value) ? new ArgumentNullOrWhiteSpaceException(LocationName) : null;
}