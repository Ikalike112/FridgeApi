using Domain.Exceptions;
using System.Collections.Generic;

namespace Application.Exceptions
{
    public sealed class CustomValidationException : ApplicationException
    {
        public CustomValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base("Validation Failure", "One or more validation errors occurred")
            => ErrorsDictionary = errorsDictionary;

        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
