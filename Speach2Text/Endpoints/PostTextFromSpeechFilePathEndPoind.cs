using FastEndpoints;
using Speach2Text.Interfaces;
using System.Linq;

namespace Speach2Text.Endpoints
{
    public class PostTextFromSpeechFilePathEndPoind : Endpoint<FilePathRequest>
    {
        private readonly ISpeechToTextService _speechToTextProvider;
        public PostTextFromSpeechFilePathEndPoind(ISpeechToTextService speechToTextProvider)
        {
            _speechToTextProvider = speechToTextProvider ?? throw new ArgumentNullException(nameof(speechToTextProvider));
        }

        public override void Configure()
        {
            Post("/api/SpeechToTextPath");
            AllowFileUploads();
            AllowAnonymous();
        }

        public override async Task HandleAsync(FilePathRequest req, CancellationToken ct)
        {
            var textResponse =  _speechToTextProvider.GetTextFromFilePath(req.FilePath);

            if (string.IsNullOrEmpty(textResponse))
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await SendOkAsync(textResponse, ct);

        }
    }
}
