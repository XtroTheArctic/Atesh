# Atesh

Atesh library is a collection of utilities.

## Highlights

- **OrderedHashSet:** A better HashSet alternative.
- **ArgumentNullOrWhiteSpaceException:** Used for String parameter validation.
- **NotNullOrWhiteSpace** Metalama aspect: Used together with its exception type.
- **IInternalsProvider** interface and **BaseClassExplicitInterfaceInvoker** class: Used for implementing "Internals" pattern.
- **Extension methods** for some built-in types: Float, String, TimeSpan, etc...

# Team Members

* Project Lead: Onur "Xtro" Er, Atesh Entertainment Inc. onurer@gmail.com

# Download and Install

You can directly install the library via [NuGet](https://www.nuget.org/packages/Atesh).

**OR**

Download it via "manual download" link in [NuGet](https://www.nuget.org/packages/Atesh) web page and extract the assembly into your project manually if you don't want to use a NuGet client.

"nupkg" file you downloaded from NuGet web page is a regular zip file. You can change its extension to "zip" and extract it easily.

# Distribution

Atesh library references Atesh.Metalama library which references Metalama.Framework library therefore, referencing Atesh in your own project will automatically make your project to use the Metalama framework.

By using Metalama framework in your project, you will be able to implement your own Metalama aspects. If that's what you want, you can keep the package reference in your `.csproj` file unmodified:

```
  <ItemGroup>
    <PackageReference Include="Atesh" Version="CHANGE ME" />
  </ItemGroup>
```

If you just want to use the existing symbols (classes, types, methods, aspects) from Atesh and Atesh.Metalama libraries and don't want to implement your own aspects, then you should modify the package reference by adding a PrivateAssets value:

```
  <ItemGroup>
    <PackageReference Include="Atesh" Version="CHANGE ME" PrivateAssets="all" />
    <PackageReference Include="Atesh.Metalama" Version="CHANGE ME" PrivateAssets="all" />
  </ItemGroup>
```

You can see the distribution section of [Metalama Documentation](https://doc.metalama.net/deployment/distributing) for more info.

# Contribution

You can easily contribute to the project by just reporting issues to [here](https://bitbucket.org/XtroTheArctic/Atesh/issues)

If you want to get involved and actively contribute to the project, you can simply do so by sending pull requests to the project lead via bitbucket.com.

Project page on [Bitbucket](https://bitbucket.org/XtroTheArctic/Atesh)

Git Repo URL: git@bitbucket.org:XtroTheArctic/atesh.git

Please feel free to contact the team members via email at any time.

# The Unlicense

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or distribute this software, either in source code form or as a compiled binary, for any purpose, commercial or non-commercial, and by any means.

In jurisdictions that recognize copyright laws, the author or authors of this software dedicate any and all copyright interest in the software to the public domain. We make this dedication for the benefit of the public at large and to the detriment of our heirs and successors. We intend this dedication to be an overt act of relinquishment in perpetuity of all present and future rights to this software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org>