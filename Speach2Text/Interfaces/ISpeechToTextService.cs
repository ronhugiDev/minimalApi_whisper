namespace Speach2Text.Interfaces
{
    public interface ISpeechToTextService
    {
        //string GetTextFromFile(Stream file);
        string GetTextFromFilePath(string filePath);
    }
}
