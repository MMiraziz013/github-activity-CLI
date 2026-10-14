using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class PullRequestEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("pull_request")]
    public object PullRequest { get; set; } = null!;

    [JsonPropertyName("assignee")]
    public object Assignee { get; set; } = null!;

    [JsonPropertyName("assignees")]
    public List<object> Assignees { get; set; } = [];

    [JsonPropertyName("label")]
    public object Label { get; set; } = null!;

    [JsonPropertyName("labels")]
    public List<object> Labels { get; set; } = [];

}