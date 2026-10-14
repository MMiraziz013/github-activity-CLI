using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs;

public class GetActorDto()
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; } = string.Empty;

    [JsonPropertyName("display_login")]
    public string DisplayLogin { get; set; } = string.Empty;

    [JsonPropertyName("gravatar_id")]
    public string GravatarId { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = string.Empty;
}