using InterviewParser.Services.Interfaces;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace InterviewParser.Services;

public class AIService(
    Kernel kernel,
    IChatCompletionService chatCompletionService) : IAIService
{
    public Task<ChatMessageContent> GetResponse(string request)
    {
        var chatHistory = new ChatHistory();

        chatHistory.AddUserMessage(request);

        return chatCompletionService.GetChatMessageContentAsync(
            chatHistory,
            kernel: kernel);
    }
}
