using Newtonsoft.Json;
using Tournamentus.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tournamentus.Core.Eseye.ApiClient
{
    public class EseyeApiClient
    {
        private readonly IHttpHandler _client;
        private EseyeApiClientSettings _clientSettings;

        public EseyeApiClient(IHttpHandler client)
        {
            _client = client;
        }

        public async Task SetClientSetting(EseyeApiClientSettings clientSettings, bool isLoggedIn, ITournamentusResponse response)
        {
            _clientSettings = clientSettings;
            _client.BaseAddress = new Uri(clientSettings.ApiBaseUrl);
            if (!isLoggedIn)
            {
                await LoginToEseyeApi(response);
            }
        }

        public async Task LoginToEseyeApi(ITournamentusResponse response)
        {
            var clientCredential = new
            {
                _clientSettings.Username,
                _clientSettings.Password,
                _clientSettings.PortfolioId
            };

            var serializedclientCredential = JsonConvert.SerializeObject(clientCredential);
            var content = new StringContent(serializedclientCredential, Encoding.UTF8, "application/json");
            var eseyeResponse = await _client.GetAsync("login"); // , content);

            if (eseyeResponse.IsSuccessStatusCode)
            {
                var eseyeResponseContent = await eseyeResponse.Content.ReadAsStringAsync();
                var eseyeResponseStatus = JsonConvert.DeserializeObject<EseyeResponseStatus>(eseyeResponseContent);

                if (eseyeResponseStatus.Status.Status == "ERR")
                {
                    response.AddEseyeErrors("EseyeAPI", eseyeResponseStatus.Status.Message);
                }
            }
            else
            {
                response.AddEseyeErrors(eseyeResponse);
            }
        }

        public async Task<EseyeResponseSIMs> GetSIMs(string url, ITournamentusResponse response)
        {
            var contentObject = new EseyeRequestGetSIMs
            {
                SearchCriteria = new EseyeRequestGetSIMs.SearchCriteriaItem
                {
                    MatchString = "1234567896841254",
                    MatchType = "E",
                    MatchFields = "I"
                }
            };

            var serializedContent = JsonConvert.SerializeObject(contentObject);
            var content = new StringContent(serializedContent, Encoding.UTF8, "application/json");
            var eseyeResponse = await _client.GetAsync(url); // , content);

            if (eseyeResponse.IsSuccessStatusCode)
            {
                var eseyeResponseContent = await eseyeResponse.Content.ReadAsStringAsync();
                var eseyeResponseStatus = JsonConvert.DeserializeObject<EseyeResponseSIMs>(eseyeResponseContent);

                if (eseyeResponseStatus.Status.Status == "OK")
                {
                    return eseyeResponseStatus;
                }
                else if (eseyeResponseStatus.Status.Status == "ERR")
                {
                    response.AddEseyeErrors("EseyeAPI", eseyeResponseStatus.Status.Message);
                    return null;
                }
            }
            else
            {
                response.AddEseyeErrors(eseyeResponse);
                return null;
            }

            return null;
        }

        public async Task<bool> Delete(string url, Guid iotId, ITournamentusResponse result)
        {
            var response = await _client.DeleteAsync($"{url}/{iotId}");

            if (!response.IsSuccessStatusCode)
            {
                result.AddEseyeErrors(response);

                return false;
            }

            return true;
        }

        public async Task<bool> Update(string url, Guid iotId, ITournamentusResponse result)
        {
            return await Update(url, iotId, new { }, result);
        }

        public async Task<bool> Update(string url, Guid iotId, object contentObject, ITournamentusResponse result)
        {
            var content = new StringContent(JsonConvert.SerializeObject(contentObject), Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync(string.Format(url, iotId), content);

            if (!response.IsSuccessStatusCode)
            {
                result.AddEseyeErrors(response);

                return false;
            }

            return true;
        }
    }
}
