using InterviewParser.Routes.Models;
using InterviewParser.Services.Interfaces;
using InterviewParser.Services.Models;

namespace InterviewParser.Services;

public class ThemeService : IThemeService
{ 
    public IEnumerable<ThemeIndex> IndexOfTheme(string interview, UtteranceResponse utteranceResponse)
    {
        var themeIndexes = new List<ThemeIndex>();

        foreach (var utterance in utteranceResponse?.Items!)
        {
            var message = utterance.Message;
            var theme = utterance.Theme;
            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(theme))
                continue;

            var index = interview.IndexOf(message);
            if (index == -1)
            {
                continue;
            }

            var themeIndex = new ThemeIndex();
            themeIndex.Theme = theme;
            themeIndex.Index = index;
            themeIndex.Length = message.Length;

            themeIndexes.Add(themeIndex);
        }
        
        return themeIndexes;
    }
}
