using Cysharp.Threading.Tasks;
using Extensions;
using Newtonsoft.Json;
using Server.Data;
using System.Net.Http;
using System;

namespace Server
{
    public class APIRequest
    {
        public async UniTask GetParsedData(Action<GameDataContainer> onSuccess, Action<Exception> onFail)
        {
            try
            {
                var client = new HttpClient();
                var url = GlobalId.API_URL;
                var httpResponce = await client.GetAsync(url);
                httpResponce.EnsureSuccessStatusCode(); // Throws an exception if the IsSuccessStatusCode property for the HTTP response is false.

                var result = await httpResponce.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GameDataContainer>(result);
                onSuccess?.Invoke(data);
            }
            catch (System.Exception exception)
            {
                onFail?.Invoke(exception);
            }
            finally
            {

            }
        }
    }
}
