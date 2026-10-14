using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class PullRequestReviewCommentEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("pull_request")]
    public object PullRequest { get; set; } = null!;

    [JsonPropertyName("comment")]
    public object Comment { get; set; } = null!;
}