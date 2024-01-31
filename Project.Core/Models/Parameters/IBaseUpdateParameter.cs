using Newtonsoft.Json;

namespace Project.Core.Models.Parameters
{
    public interface IBaseUpdateParameter
    {

        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string UpdateBy { get; set; }
    }
}
