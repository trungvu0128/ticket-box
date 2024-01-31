using Newtonsoft.Json;

namespace Project.Core.Models
{
    public interface IBaseAddParameter

    {
        [JsonIgnore]
        public string CreateBy { get; set; }
    }
}
