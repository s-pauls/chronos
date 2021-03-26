using Chronos.Core.Microsoft.AzureDevOps.Extensions;
using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Chronos.Domain.Entities.User;

namespace Chronos.Core.Microsoft.AzureDevOps
{
    public class UserService: IUserService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of <see cref="UserService" /> class
        /// </summary>
        public UserService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<User> Get(string accessToken)
        {
            return GetAsync<User>(accessToken, "https://app.vssps.visualstudio.com/_apis/profile/profiles/me");
        }

        protected async Task<T> GetAsync<T>(string accessToken, string uri)
        {
            return await _httpClient.GetAsync<T>(accessToken, uri);
        }
    }
}
