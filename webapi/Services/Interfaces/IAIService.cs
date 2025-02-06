using Microsoft.SemanticKernel;

namespace InterviewParser.Services.Interfaces;

public interface IAIService
{
    Task<ChatMessageContent> GetResponse(string text);
}
