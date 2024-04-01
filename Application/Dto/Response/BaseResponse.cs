namespace Application.Dto.Response;

public class BaseResponse(bool isSuccess)
{
    public bool IsSuccess { get; set; } = isSuccess;
}