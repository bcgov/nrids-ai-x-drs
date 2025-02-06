using InterviewParser.Services;
using InterviewParser.Services.Interfaces;

namespace InterviewParser.Core;

public static class ServiceExtenstions
{
    public static WebApplicationBuilder AddAIService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAIService, AIService>();
        builder.Services.AddScoped<IThemeService, ThemeService>();

        return builder;
    }
}
