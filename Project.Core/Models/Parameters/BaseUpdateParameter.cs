using Newtonsoft.Json;
using Project.Core.Models.Parameters;

namespace Project.Core.Models
{
    public class BaseUpdateParameter : IBaseUpdateParameter
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string UpdateBy { get; set; } = default!;
    }
}
