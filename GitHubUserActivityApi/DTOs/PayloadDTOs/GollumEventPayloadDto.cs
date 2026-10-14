using System.Text.Json.Serialization;

namespace GitHubUserActivityApi.DTOs.PayloadDTOs;

public class GollumEventPayloadDto
{
    [JsonPropertyName("pages")]
    public List<GetGollumPageDto> GollumPageDtos { get; set; } = [];
}