using WarmSide.WebFace.Models;
using WarmSide.WebFace.Interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Collections.Generic;

namespace WarmSide.WebFace
{
    public class UserManager
    {
        private readonly string _accountServerUri;
        private readonly IHttpClientFactory _httpFactory;

        public UserManager(string accountServerUri, IHttpClientFactory httpFactory)
        {
            _accountServerUri = accountServerUri;
            _httpFactory = httpFactory;
        }

        public async Task<bool> AddUser(User user)
        {
            string url = $"{_accountServerUri}AddUser";

            using (var client = _httpFactory.CreateClient())
            {
                var response = await client.PostAsJsonAsync<User>(url, user);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<User> FindUserById(string nameIdentifier)
        {
            string url = $"{_accountServerUri}GetUser/{nameIdentifier}";

            User result;

            using (var client = _httpFactory.CreateClient())
            {
                var response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    result = await response.Content.ReadAsAsync<User>(new List<MediaTypeFormatter>() { new JsonMediaTypeFormatter() });
                }

                return result;
            }
        }
    }
}