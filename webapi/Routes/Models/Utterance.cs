using System.Text.Json.Serialization;

namespace InterviewParser.Routes.Models;

public record Utterance
{
    [JsonPropertyName("id")]
    public int? Id { get; init; } 

    [JsonPropertyName("user")]
    public string? User { get; init; }

    [JsonPropertyName("theme")]
    public string? Theme { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
