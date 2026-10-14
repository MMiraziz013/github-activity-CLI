using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class DeleteEventPayloadDto
{
    [JsonPropertyName("ref")]
    public string Ref { get; set; } = string.Empty;

    [JsonPropertyName("ref_type")]
    public string RefType { get; set; } = string.Empty;

    [JsonPropertyName("full_ref")]
    public string FullRef { get; set; } = string.Empty;

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; set; } = string.Empty;
}