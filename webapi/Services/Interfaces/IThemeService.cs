using InterviewParser.Services.Models;
using InterviewParser.Routes.Models;

namespace InterviewParser.Services.Interfaces;

public interface IThemeService
{
    IEnumerable<ThemeIndex> IndexOfTheme(string text, UtteranceResponse utteranceResponse);
}
