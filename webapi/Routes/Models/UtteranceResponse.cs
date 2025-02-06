using System.Text.Json.Serialization;

namespace InterviewParser.Routes.Models;

public record UtteranceResponse
{
    [JsonPropertyName("themes")]
    public IEnumerable<string>? Themes { get; init; }

    [JsonPropertyName("items")]
    public IEnumerable<Utterance>? Items { get; init; }
}
