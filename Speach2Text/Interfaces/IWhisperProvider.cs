namespace Speach2Text.Interfaces
{
    public interface IWhisperProvider
    {
        string ProvideText(string audioFilePath);
        //string ProvideText(Stream streamFile);
    }
}
