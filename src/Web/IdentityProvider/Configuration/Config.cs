using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdentityProvider.Configuration
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("cidadao", "Cidadao API"),
                new ApiResource("cidadao.read", "Cidadao API"),
                new ApiResource("cidadao.write", "Saude API"),
                new ApiResource("saude", "Saude API"),
                new ApiResource("saude.read", "Saude API"),
                new ApiResource("saude.write", "Saude API"),
                new ApiResource("manager", "Manager API")
            };
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
        public static IEnumerable<Client> Clients => new List<Client>
            {
                new Client
                {
                    ClientId = "cidadao-client",
                    ClientName = "Cidadao Credentials for Cidadao API",
                    ClientSecrets = { new Secret("cidadao-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new Collection<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "cidadao",
                        "cidadao.read","cidadao.write","adm"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                new Client
                {
                    ClientId = "manager-client",
                    ClientName = "Manager Credentials for Manager API",
                    ClientSecrets = { new Secret("manager-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new Collection<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "manager","adm",
                        "cidadao.read","manager.read","saude.read",
                        "cidadao.write","manager.write","saude.write"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                new Client
                {
                    ClientId = "saude-client",
                    ClientName = "Saude Credentials for Saude API",
                    ClientSecrets = { new Secret("saude-secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new Collection<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "saude","adm",
                        "saude.read", "saude.write"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
            };

    }
}