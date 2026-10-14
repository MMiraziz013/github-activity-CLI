using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class PullRequestReviewPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("pull_request")]
    public object PullRequest { get; set; } = null!;

    [JsonPropertyName("review")]
    public object Review { get; set; } = null!;


}