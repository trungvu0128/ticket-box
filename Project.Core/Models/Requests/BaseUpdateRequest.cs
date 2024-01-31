using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace Project.Core.Models.Requests
{
    [ValidateNever]
    public record BaseUpdateRequest
    {
        [JsonIgnore]
        public int Id { get; set; } = default!;
        [JsonIgnore]
        public string UpdateBy { get; set; } = default!;
    }
}
