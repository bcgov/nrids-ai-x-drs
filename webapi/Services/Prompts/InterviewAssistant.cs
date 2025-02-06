using System.Text.Json;

namespace InterviewParser.Services.Prompts;

public static class InterviewAssistant
{
    private static string THEME_PROMPT = @"
        You are a research assistant working for the British Columbia Ministry of Transportation and Transit.
        You have been given an interview between your peers and a members of the public. Your task is to do the following:
            1.
            List the themes of the interview. The themes should be two or three words long.
            The list of themes should be a JSON list of strings that are in a snakecase format. Here is an example:
                [ ""theme_one"", ""theme_number_two"", ""theme_three"" ]

            The only response you should be giving is the json object found in step 1.
            Do not add any markdown support tags to your response.

        Here is the interview:
        ";

    private static string THEME_SEGMENT_PROMPT(IEnumerable<string> themes) => @"
        You are a research assistant working for the British Columbia Ministry of Transportation and Transit.
        You have been given an interview between your peers and a members of the public. You have also been given a list
        of themes. Your task is to do the following:
            1.
            Identify sections of the interview that relate to the provided themes and identify who delivered that section of the interview.
            Return this as a JSON object. If a section does not relate to any theme it can be excluded from the JSON object.
            Each returned section should also have a unique number that increments. The JSON object should follow this format:
            [
                {
                    id: 1,
                    user: User One,
                    theme: theme_one,
                    message: This is a section of the interview. It can contain multiple sentences. It must be only related to one speaker.
                },
                {
                    id: 2,
                    user: User Two,
                    theme: theme_number_two,
                    message: This is a different section of the interview.
                }
            ]

            Do not alter any of the text in the interview being provided.
            When you return a section of the interview it is VERY important that you return the exact text from the interview.
            This includes any whitespaces such as newline characters.

            The only response you should be giving is the json object found in step 1.
            Do not add any markdown support tags to your response.

        Here are the themes:" +
        JsonSerializer.Serialize(themes) +

        @"Here is the interview:
        ";

    public static string GetThemePrompt(string interview) => $"{THEME_PROMPT}{interview}";

    public static string GetThemeSegmentsPrompt(IEnumerable<string> themes, string interview) => $"{THEME_SEGMENT_PROMPT(themes)}{interview}";
}
