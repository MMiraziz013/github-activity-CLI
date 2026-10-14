using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class CreateEventPayloadDto
{
    [JsonPropertyName("ref")]
    public string Ref { get; set; } = string.Empty;

    [JsonPropertyName("ref_type")]
    public string RefType { get; set; } = string.Empty;

    [JsonPropertyName("full_ref")]
    public string FullRef { get; set; } = string.Empty;

    [JsonPropertyName("master_branch")]
    public string MasterBranch { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; set; } = string.Empty;
}