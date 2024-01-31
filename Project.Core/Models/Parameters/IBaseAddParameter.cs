using Newtonsoft.Json;

namespace Project.Core.Models.Parameters
{
    public class BaseAddParameter : IBaseAddParameter

    {
        [JsonIgnore]
        public string CreateBy { get; set; } = default!;
    }
}
