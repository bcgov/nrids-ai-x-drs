using System.Text.Json.Serialization;

namespace InterviewParser.Routes.Models;

public record UtteranceCheckSum
{
    [JsonPropertyName("cover_percentage")]
    public int? CoverPercentage { get; init; }

    [JsonPropertyName("themes")]
    public IEnumerable<string>? Themes { get; init; }

    [JsonPropertyName("utterances")]
    public IEnumerable<Utterance>? Utterances { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
