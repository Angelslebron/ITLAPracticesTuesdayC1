namespace SecuresCompany.Application.Core;

public abstract class BaseService
{
    protected ServiceResult Success(string message = null)
        => ServiceResult.SuccessResult(message);

    protected ServiceResult Error(string message)
        => ServiceResult.ErrorResult(message);
}