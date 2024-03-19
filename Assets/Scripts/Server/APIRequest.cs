using Cysharp.Threading.Tasks;
using Extensions;
using Newtonsoft.Json;
using System.Net.Http;

namespace Server
{
    public class APIRequest
    {
        private string _url;

        public APIRequest(string url)
        {
            _url = url;
        }

        public async UniTask<RequstResult<T>> GetParsedData<T>()
        {
            try
            {
                var client = new HttpClient();
                var httpResponce = await client.GetAsync(_url);
                httpResponce.EnsureSuccessStatusCode(); 

                var result = await httpResponce.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(result);
                return new RequstResult<T>(data);
            }
            catch (System.Exception exception)
            {
                return new RequstResult<T>(exception);
            }
        }
    }
}
