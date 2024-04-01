namespace Application.Dto.Auth;

public class TokenDto(string token, DateTime expires, string tokenType)
{
    public string AccessToken { get; set; } = token;
    public DateTime Expires { get; set; } = expires;
    public string TokenType { get; set; } = tokenType;
}