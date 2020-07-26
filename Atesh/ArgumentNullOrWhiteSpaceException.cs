using System;

namespace Atesh
{
    public class ArgumentNullOrWhiteSpaceException : ArgumentException
    {
        public ArgumentNullOrWhiteSpaceException() : base(Strings.ArgumentCantBeNullOrEmpty) { }
        public ArgumentNullOrWhiteSpaceException(string ParamName) : base(Strings.ArgumentCantBeNullOrEmpty, ParamName) { }
        public ArgumentNullOrWhiteSpaceException(string Message, Exception InnerException) : base(Message, InnerException) { }
        public ArgumentNullOrWhiteSpaceException(string ParamName, string Message) : base(Message, ParamName) { }
    }
}