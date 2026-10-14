using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class WatchEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;
}