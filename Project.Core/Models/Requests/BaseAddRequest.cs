using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace Project.Core.Models.Requests
{
    [ValidateNever]
    public record BaseAddRequest
    {
        [JsonIgnore]
        public string CreateBy { get; set; } = default!;
    }
}
