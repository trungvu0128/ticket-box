using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace Shared.Helper
{
    public class RestApiHelper
    {
        public async Task<HttpResponseMessage> GetRequestAsync(string url, object? param, string correlationID = "", Dictionary<string, string>? headers = null)
        {
            try
            {
                using HttpClient client = new();
                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                if (param != null)
                {
                    url = $"{url}{GetQueryString(param)}";
                }
                HttpResponseMessage response = await client.GetAsync(url);
                if (response == null)
                {
                    throw new Exception($"Call {url}: Failed. Response is null");
                }
                if (response.IsSuccessStatusCode != true && response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception($"Call {url}: Failed. Response StatusCode {response.StatusCode}: ${response.ReasonPhrase}");
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        public async Task<HttpResponseMessage> PostRequestAsync(string url, object? param, string correlationID = "", Dictionary<string, string>? headers = null)
        {
            using HttpClient client = new();
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

                }
            }
            HttpResponseMessage response;
            if (param == null)
            {
                response = await client.PostAsJsonAsync(url, new { });
            }
            else
            {
                response = await client.PostAsJsonAsync(url, param);
            }
            if (response == null)
            {
                throw new Exception($"Call {url}: Failed. Response is null");
            }
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Call {url}: Failed. Response StatusCode {response.StatusCode}: ${response.ReasonPhrase}. Content:{response.Content.ReadAsStringAsync().Result}");
            }
            return response;
        }
        public async Task<HttpResponseMessage> PutRequestAsync(string url, object? param, string correlationID = "", Dictionary<string, string>? headers = null)
        {
            using HttpClient client = new();
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

                }
            }
            HttpResponseMessage response;
            if (param == null)
            {
                response = await client.PutAsJsonAsync(url, new { });
            }
            else
            {
                response = await client.PutAsJsonAsync(url, param);
            }

            if (response == null)
            {
                throw new Exception($"Call {url}: Failed. Response is null");
            }
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Call {url}: Failed. Response StatusCode {response.StatusCode}: ${response.ReasonPhrase}");
            }
            return response;
        }
        public async Task<HttpResponseMessage> DeleteRequestAsync(string url, object? param, string correlationID = "", Dictionary<string, string>? headers = null)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("CorrelationID", correlationID);
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);

                }
            }
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response == null)
            {
                throw new Exception($"Call {url}: Failed. Response is null");
            }
            if (response.IsSuccessStatusCode != true)
            {
                throw new Exception($"Call {url}: Failed. Response StatusCode {response.StatusCode}: ${response.ReasonPhrase}");
            }
            return response;
        }
        public string GetQueryString(object obj)
        {
            var test = JsonSerializer.Serialize(obj);
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());


            string rs = string.Join("&", properties.ToArray());
            if (!string.IsNullOrEmpty(rs))
                return $"?{rs}";
            return string.Empty;
        }
    }
}
