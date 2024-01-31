using Newtonsoft.Json;

namespace Shared.Helper
{
    public static class JsonHelper<T>
    {

        public static T? Deserialize(string json)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Serialize(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}