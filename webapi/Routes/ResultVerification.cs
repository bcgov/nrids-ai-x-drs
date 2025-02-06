using InterviewParser.Routes.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewParser.Routes;

public static class ResultVerification
{
    public static void AddResultVerification(this WebApplication app)
    {
        app.MapPost("/verifications", VerifyDataIntegrity);
    }

    private static IEnumerable<string> VerifyDataIntegrity(
        [FromBody] UtteranceCheckSum utteranceCheckSum)
    {
        var errors = new List<string>();
        var text = utteranceCheckSum.Text;

        if (string.IsNullOrEmpty(text))
            return errors;

        if (utteranceCheckSum.Utterances == null)
            return errors;

        foreach (var utterance in utteranceCheckSum.Utterances)
        {
            var message = utterance.Message;

            if (string.IsNullOrEmpty(message))
                continue;
            
            if (!text.Contains(message))
            {
                errors.Add($"Message not found in original text: {utterance.Message}");
            }
        }

        return errors;
    }
}
