namespace Application.Dto.User;

public class UserSearchQueryDto : BasePageableQuery
{
    public string? Search { get; set; }
}