using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class CommitCommentEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("comment")] public object Comment { get; set; } = null!;

}