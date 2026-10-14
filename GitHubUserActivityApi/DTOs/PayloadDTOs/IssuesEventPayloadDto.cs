using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class IssuesEventPayloadDto
{
    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonPropertyName("issue")]
    public object Issue { get; set; } = null!;

    [JsonPropertyName("assignee")]
    public object Assignee { get; set; } = null!;

    [JsonPropertyName("assignees")]
    public List<object> Assignees { get; set; } = [];

    [JsonPropertyName("label")]
    public object Label { get; set; } = null!;

    [JsonPropertyName("labels")]
    public List<object> Labels { get; set; } = [];
}