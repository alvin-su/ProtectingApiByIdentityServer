using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pai.AuthorizationServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("MyApi1", "My API V1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ConsoleClient",

                      //使用clientid / secret进行身份验证 OAuth2.0的客户端模式
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AccessTokenLifetime=2, //token有效期,设置为2个小时，默认1个小时 3600秒

                    
                     // 加密验证
                    ClientSecrets =
                    {
                        new Secret("ConsoleSecret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "MyApi1" }
                }
            };
        }
    }
}
