using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blip.Api.AudioProcessor.Services
{
    public interface IAudioTranscriptor
    {
        Task<string> TranscriptFromMp4UriAsync(string uri);
    }
}
