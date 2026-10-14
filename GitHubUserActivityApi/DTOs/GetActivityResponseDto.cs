using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs;

public class GetActivityResponseDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("actor")]
    public GetActorDto? Actor { get; set; }

    [JsonPropertyName("repo")]
    public GetRepoDto? Repo { get; set; }

    [JsonPropertyName("payload")]
    public JsonElement Payload { get; set; }

    [JsonPropertyName("public")]
    public bool Public { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = string.Empty;
}