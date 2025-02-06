using System.Text.Json.Serialization;

namespace InterviewParser.Services.Models;

public class ThemeIndex
{
    [JsonPropertyName("theme")]    
    public string Theme { get; set; } = "";

    [JsonPropertyName("index")]    
    public int Index { get; set; }

    [JsonPropertyName("length")]    
    public int Length { get; set; }
}
