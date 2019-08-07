using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blip.Api.AudioProcessor.Services.Transcriptors
{
    public interface ISpeechTranscriptor
    {
        Task<string> Transcript(string wavFilePath);
    }
}
