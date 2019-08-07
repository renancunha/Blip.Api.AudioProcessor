using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blip.Api.AudioProcessor.Services.Transcriptors;

namespace Blip.Api.AudioProcessor.Services
{
    public class AudioTranscriptor : IAudioTranscriptor
    {
        private readonly IMediaDownloader _mediaDownloader;
        private readonly IMediaConversor _mediaConversor;
        private readonly ISpeechTranscriptor _speechTranscriptor;

        public AudioTranscriptor(
            IMediaDownloader mediaDownloader,
            IMediaConversor mediaConversor,
            ISpeechTranscriptor speechTranscriptor
            )
        {
            _mediaConversor = mediaConversor;
            _mediaDownloader = mediaDownloader;
            _speechTranscriptor = speechTranscriptor;
        }

        public async Task<string> TranscriptFromMp4UriAsync(string uri)
        {
            var mp4File = _mediaDownloader.DownloadFromUri(uri);
            var wavFile = await _mediaConversor.ConvertMp4ToWavAsync(mp4File);
            var transcript = await _speechTranscriptor.Transcript(wavFile);

            return transcript;
        }
    }
}
