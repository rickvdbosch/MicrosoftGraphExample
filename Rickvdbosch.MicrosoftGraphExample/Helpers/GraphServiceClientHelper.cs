using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.Graph;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Rickvdbosch.MicrosoftGraphExample.Helpers
{
    public static class GraphServiceClientHelper
    {
        #region Fields

        //TODO: Fill in your tenant ID
        private static string _tenant => "<YOUR_AAD_TENANT>.onmicrosoft.com";

        //TODO: fill on your application ID
        private static string _appId => "YOUR_APPLICATION_ID";

        //TODO: Fill in your application secret
        private static string _appSecret => "YOUR_APPLICATION_SECRET";

        #endregion

        public static GraphServiceClient CreateGraphServiceClient()
        {
            var clientCredential = new ClientCredential(_appId, _appSecret);
            var authenticationContext = new AuthenticationContext($"https://login.microsoftonline.com/{_tenant}");
            var authenticationResult = authenticationContext.AcquireTokenAsync("https://graph.microsoft.com", clientCredential).Result;

            var delegateAuthProvider = new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", authenticationResult.AccessToken);

                return Task.FromResult(0);
            });

            return new GraphServiceClient(delegateAuthProvider);
        }
    }
}