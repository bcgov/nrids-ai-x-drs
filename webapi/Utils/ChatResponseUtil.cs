using Microsoft.SemanticKernel;
using System.Text.Json;

namespace InterviewParser.Utils;

public static class InterviewChatResponseUtil
{
    public static IEnumerable<T>? GetResponseCollection<T>(ChatMessageContent content)
        where T : class
    {
        Console.WriteLine(GetTextContent(content)?.Text);
        return JsonSerializer.Deserialize<IEnumerable<T>>(
                GetTextContent(content)?.Text ?? string.Empty);
    }

    private static TextContent? GetTextContent(ChatMessageContent content)
        => content.Items
            .Where(item => item.GetType() == typeof(TextContent))
            .FirstOrDefault()
            as TextContent;
}
