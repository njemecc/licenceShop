using LicenceShop.Domain.Exceptions;

namespace LicenceShop.Application.Common.Exceptions;

public class ApplicationException : BaseException
{
    public ApplicationException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }

    public ApplicationException(string message, Exception innerException, object? additionalData = null) : base(message,
        innerException,
        additionalData)
    {
    }
}
