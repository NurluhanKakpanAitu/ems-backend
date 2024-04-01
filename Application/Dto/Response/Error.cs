namespace Application.Dto.Response;

public class Error(string errorMessage) : BaseResponse(false)
{
    public string ErrorMessage { get; set; } = errorMessage;
}