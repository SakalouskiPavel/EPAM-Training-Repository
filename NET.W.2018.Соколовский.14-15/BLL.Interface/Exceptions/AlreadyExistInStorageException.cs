using System;

namespace BLL.Interface.Exceptions
{
    public class AlreadyExistInStorageException : Exception
    {
        public AlreadyExistInStorageException() : base("This item is already exists in this storage")
        {
        }
    }
}