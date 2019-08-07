# AudioProcessor - REST API
 
## Overview
TODO

## Setup & Running

### Setup Azure Credentials

You need to update ``appsettings.json``, inside ``src/Blip.Api.AudioProcessor`` with your Azure credentials. To run that application you'll need a Speech Subscription Key from the [Azure Cognitive Services](https://azure.microsoft.com/pt-br/services/cognitive-services/speech-to-text/).

Properties to be configured:

````
"AzureSpeechSubscriptionKey": "YOUR-SUBSCRIPTION-KEY",
"AzureSpeechRecognitionLanguage": "pt-BR",
"AzureRegion": "westus",
````

### Run
Just run ``dotnet run`` inside ``src/Blip.Api.AudioProcessor`` and voi'la.

## Authors

- Renan Cunha (renan.santos@take.net)
- José Nondas (jose.silva@take.net) 
