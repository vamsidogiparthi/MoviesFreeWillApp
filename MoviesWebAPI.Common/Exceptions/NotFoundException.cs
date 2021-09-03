using System;

namespace MoviesWebAPI.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        public NotFoundException(string message = null) :
            base(message == null ? "Record does not exist" : message)
        {

        }
    }
}