#nullable enable

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace Atesh.Metalama;

public class NotNullOrWhiteSpaceAttribute : ContractAspect
{
    // ReSharper disable once InconsistentNaming
    public override void Validate(dynamic? value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullOrWhiteSpaceException(((INamedDeclaration)meta.Target.Declaration).Name);
    }
}