using System;

namespace Indimin.Challenge.Tasking.Domain.Exceptions
{
    public class TaskingDomainException : Exception
    {
        public TaskingDomainException()
        { }

        public TaskingDomainException(string message)
            : base(message)
        { }

        public TaskingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
