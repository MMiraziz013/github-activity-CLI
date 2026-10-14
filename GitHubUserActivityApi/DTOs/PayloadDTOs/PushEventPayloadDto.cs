using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class PushEventPayloadDto
{
    [JsonPropertyName("repository_id")]
    public int RepositoryId { get; set; }
    [JsonPropertyName("push_id")]
    public long PushId { get; set; }
    [JsonPropertyName("ref")]
    public string Ref { get; set; } = string.Empty;
    [JsonPropertyName("head")]
    public string Head { get; set; } = string.Empty;
    [JsonPropertyName("before")]
    public string Before { get; set; } = string.Empty;
}