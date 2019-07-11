using System;

namespace Rsobies.NuBuilder
{
    public class ValidationException : Exception
    {
        public LibTarget MissingTarget
        {
            get;
        }
        public ValidationException(string message, LibTarget target) : base(message)
        {
            MissingTarget = target;
        }
    }
}
