using FluentValidation.Results;
using Speach2Text.Interfaces;
using FluentValidation;

namespace Speach2Text.Services
{
    public class SpeechToTextService : ISpeechToTextService
    {
        private readonly IWhisperProvider _whisperProvider;
        public SpeechToTextService(IWhisperProvider whisperProvider)
        {
                _whisperProvider = whisperProvider?? throw new ArgumentNullException(nameof(whisperProvider));
        }
        public string GetTextFromFile(Stream file)
        {
            return "";
        }

        public string GetTextFromFilePath(string filePath)
        {      
            if (File.Exists(filePath)){
                return _whisperProvider.ProvideText(filePath);
            }

            return string.Empty;
        }
    }
}
