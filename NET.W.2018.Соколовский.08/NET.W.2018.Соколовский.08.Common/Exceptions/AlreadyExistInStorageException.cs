using System;

namespace NET.W._2018.Соколовский._08.Common.Exceptions
{
    public class AlreadyExistInStorageException : Exception
    {
        public AlreadyExistInStorageException() : base("This item is already exists in this storage")
        {
        }
    }
}