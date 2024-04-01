namespace Application.Dto.Response;

public class Success(bool isSuccess, object? data) : BaseResponse(true)
{
    public object? Data { get; set; } = data;
}