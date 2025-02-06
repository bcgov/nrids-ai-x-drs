using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace InterviewParser.Core;

public static class SemanticKernelExtensions
{
    public static WebApplicationBuilder AddSemanticKernel(this WebApplicationBuilder builder)
    {
        var modelId = "";
        var endpoint = "";
        var apiKey = "";

        var kernel = Kernel
            .CreateBuilder()
            .AddAzureOpenAIChatCompletion(modelId, endpoint, apiKey)
            .Build();
        var chatCompletionService = kernel.Services.GetRequiredService<IChatCompletionService>();

        builder.Services.AddSingleton<Kernel>(services => kernel);
        builder.Services.AddScoped<IChatCompletionService>(services => chatCompletionService);
 
        return builder;
    }
}
