namespace InterviewParser.Utils;

public static class FileUtil
{
    public static string ReadFile(IFormFile file)
    {
        using StreamReader reader = new(file.OpenReadStream());
        return reader.ReadToEnd();
    }
}
