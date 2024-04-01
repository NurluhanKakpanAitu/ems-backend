using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Persistence;

public static class Config
{
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>
        {
            new ApiScope("EMSWebAPI", "Web API")
        };
    }
    
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }
    
    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris = { "https://localhost:5001/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },
                AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, "EMSWebAPI"},
                AllowedCorsOrigins = { "https://localhost:5001" },
                AllowAccessTokensViaBrowser = true,
            }
        };
    }
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("EMSWebAPI", "Web API", new[] { JwtClaimTypes.Name })
            {
                Scopes = { "EMSWebAPI" }
            }
        };
    }
    
}