namespace SecuresCompany.Application.Core;

public class ServiceResult
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public static ServiceResult SuccessResult(string message = null)
        => new() { Success = true, Message = message };

    public static ServiceResult ErrorResult(string message)
        => new() { Success = false, Message = message };
}