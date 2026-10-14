using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class IssueCommentEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("issue")]
    public object Issue { get; set; } = null!;

    [JsonPropertyName("comment")]
    public object Comment { get; set; } = null!;


}