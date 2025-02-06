using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace InterviewParser.Routes.Filters;

public static class AIResponse
{
    public static async ValueTask<object?> AIResponseFilter(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next(context);

        if (result == null)
            return null;

        if (result.GetType() != typeof(OpenAIChatMessageContent))
            return null;

        var content = (OpenAIChatMessageContent)result;

        var response = (TextContent?)content.Items
            .Where(item => item.GetType() == typeof(TextContent))
            .FirstOrDefault();

        if (response == null)
            return null;

        return response.Text;
    }
}
