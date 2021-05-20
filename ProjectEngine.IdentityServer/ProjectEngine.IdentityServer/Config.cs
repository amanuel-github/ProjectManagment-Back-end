using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceapi", "Resource API")
                {
                    Scopes = {new Scope("api.read")}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            var secret = new Secret("secret".Sha256());

            return new[]
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "Project_Engine",
                    ClientName = "Project Engine",
                    ClientSecrets = { secret },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "api.read" },
                    //RedirectUris = { "http://localhost:4200/auth/auth-callback" },
                    RedirectUris = {"http://127.0.0.1:8080/auth/auth-callback"},
                    //PostLogoutRedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = {"http://127.0.0.1:8080"},
                    //AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedCorsOrigins = {"http://127.0.0.1:8080"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 60 ,
                    RequirePkce = true,
                    RequireClientSecret = false,
                }
            };
        }
    }
}
