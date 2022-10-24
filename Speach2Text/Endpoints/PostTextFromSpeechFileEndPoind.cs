using FastEndpoints;
using Speach2Text.Contracts.Requests;
using Speach2Text.Interfaces;
using Speach2Text.Providers;
using Speach2Text.Services;

namespace Speach2Text.Endpoints
{
    public class PostTextFromSpeechFileEndPoind : Endpoint<FileRequest>
    {
        private readonly ISpeechToTextService _speechToTextProvider;
        public PostTextFromSpeechFileEndPoind(ISpeechToTextService speechToTextProvider)
        {
            _speechToTextProvider = speechToTextProvider ?? throw new ArgumentNullException(nameof(speechToTextProvider));
        }

        public override void Configure()
        {
            Post("/api/SpeechToTextFile");
            AllowFileUploads();
            AllowAnonymous();
        }

        public override async Task HandleAsync(FileRequest req, CancellationToken ct)
        {

            //_speechToTextProvider.GetTextFromFile(new object());
            //if (Files.Count > 0)
            //{
            //    var file = Files[0];

            //    await SendStreamAsync(
            //        stream: file.OpenReadStream(),
            //        fileName: "test.png",
            //        fileLengthBytes: file.Length,
            //        contentType: "image/png");

            //    return;
            //}
            //await SendNoContentAsync();
        }
    }
}
