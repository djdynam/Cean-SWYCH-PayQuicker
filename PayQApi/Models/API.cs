using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayQApi.Models
{
    public class API
    {
        private string AccessToken = "";

        public async Task<T> SendAsync<T, T1>(T1 data, string url)
        {
            using (var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://private-anon-75198ad1f4-payquickerv101152018.apiary-mock.com/")
            })

            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("x-mypayquicker-version", "01-15-2018");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", $"Bearer {AccessToken}");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync(url, content))

                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(responseData);
                    }
                }
            }
        }

        public async Task<List<InvitationsResponse>> SendInvitations(List<Invitations> i) => await SendAsync<List<InvitationsResponse>, List<Invitations>>(i, "api/v1/companies/users/invitations");

        public async Task<List<PaymentRespose>> SendPayment(SendPayments i) => await SendAsync<List<PaymentRespose>, SendPayments>(i, "api/v1/companies/accounts/payments");

        public async Task<OAuthResponse> SendGetToken(OAuth i) => await SendAsync<OAuthResponse, OAuth>(i, "core/connect/token");
    }
}