using System;

namespace Forca.Entities.Exceptions
{
    class ForcaException : ApplicationException
    {
        public ForcaException(string message) : base(message)
        {
        }
    }
}
