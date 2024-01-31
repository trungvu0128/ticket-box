using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Core.Models.Responses
{
    public record BasePagingResponse
    {
        [JsonIgnore]
        public int? TotalRow { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int TotalPage { get; set; }
    }
}
