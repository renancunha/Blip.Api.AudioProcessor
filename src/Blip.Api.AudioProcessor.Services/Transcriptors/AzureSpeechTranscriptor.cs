using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Blip.Api.AudioProcessor.Services.Transcriptors
{
    public class AzureSpeechTranscriptor : ISpeechTranscriptor
    {
        private readonly AzureSettings _azureSettings;

        public AzureSpeechTranscriptor(AzureSettings azureSettings)
        {
            _azureSettings = azureSettings;
        }

        public async Task<string> Transcript(string wavFilePath)
        {
            var config = GetSpeechConfig();

            using (var recognizer = new SpeechRecognizer(config, AudioConfig.FromWavFileInput(wavFilePath)))
            {
                var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    return result.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private SpeechConfig GetSpeechConfig()
        {
            var config = SpeechConfig.FromSubscription(_azureSettings.AzureSpeechSubscriptionKey, _azureSettings.AzureRegion);
            config.SpeechRecognitionLanguage = _azureSettings.AzureSpeechRecognitionLanguage;
            return config;
        }
    }
}
