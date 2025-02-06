using InterviewParser.Routes.Models;
using InterviewParser.Services.Interfaces;
using InterviewParser.Services.Models;
using InterviewParser.Services.Prompts;
using InterviewParser.Utils;

namespace InterviewParser.Routes;

public static class Interview
{
    public static void AddInterviewRoutes(this WebApplication app)
    {
        app.MapPost("/interviews", UploadInterview)
            .RequireCors("localhost")
            .DisableAntiforgery();
    }

    public async static Task<IEnumerable<ThemeIndex>?> UploadInterview(
        IAIService aiService,
        IThemeService themeService,
        IFormFileCollection files)
    {
        var interviewText = FileUtil.ReadFile(files[0]);

        if (string.IsNullOrWhiteSpace(interviewText))
            return null;
 
        var themePrompt = InterviewAssistant.GetThemePrompt(interviewText);
        var themeResponse = await aiService.GetResponse(themePrompt);
        var themes = InterviewChatResponseUtil.GetResponseCollection<string>(themeResponse);

        var utterancesPrompt = InterviewAssistant.GetThemeSegmentsPrompt(themes!, interviewText);
        var interviewSegmentRespose = await aiService.GetResponse(utterancesPrompt);
        var utterances = InterviewChatResponseUtil.GetResponseCollection<Utterance>(interviewSegmentRespose);

        var utteranceResponse = new Models.UtteranceResponse()
        {
            Themes = themes,
            Items = utterances
        };

        return themeService.IndexOfTheme(interviewText, utteranceResponse);
    }
}
