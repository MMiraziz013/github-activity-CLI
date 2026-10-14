using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class ForkEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("forkee")]
    public object Forkee { get; set; } = null!;

}