using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blip.Api.AudioProcessor.Models;
using Blip.Api.AudioProcessor.Services;
using Blip.Api.AudioProcessor.Services.Transcriptors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blip.Api.AudioProcessor.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {
        private readonly IAudioTranscriptor _audioTranscriptor;

        public TranscriptController(IAudioTranscriptor audioTranscriptor)
        {
            _audioTranscriptor = audioTranscriptor;
        }

        // POST api/transcript/audio-to-text
        /// <summary>
        /// Transcript an audio file to text using Azure Cognitive Services
        /// </summary>
        /// <param name="body">You should inform the uri to the media link that will be recognized</param>
        /// <returns></returns>
        [HttpPost("audio-to-text")]
        public async Task<TranscriptTextResponse> AudioToTextAsync([FromBody]TranscriptRequestBody body)
        {
            var text = await _audioTranscriptor.TranscriptFromMp4UriAsync(body.Uri);
            return new TranscriptTextResponse { Text = text };
        }
    }
}
