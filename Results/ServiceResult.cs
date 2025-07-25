namespace agora_shop.Results;

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }

    public static ServiceResult<T> Ok(T data) =>
        new ServiceResult<T> { Success = true, Data = data };

    public static ServiceResult<T> Failure(string message) =>
        new ServiceResult<T> { Success = false, ErrorMessage = message };
}