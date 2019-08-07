using System;
using System.Collections.Generic;
using System.Text;

namespace Blip.Api.AudioProcessor.Services.Transcriptors
{
    public class AzureSettings
    {
        public string AzureSpeechSubscriptionKey { get; set; }

        public string AzureSpeechRecognitionLanguage { get; set; }

        public string AzureRegion { get; set; }

    }
}
