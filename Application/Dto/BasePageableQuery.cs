namespace Application.Dto;

public class BasePageableQuery
{
    public int PageNumber { get; set; } = 1;
    
    public int PageSize { get; set; } = 10;
}