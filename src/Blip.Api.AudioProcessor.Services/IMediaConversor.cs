using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blip.Api.AudioProcessor.Services
{
    public interface IMediaConversor
    {
        Task<string> ConvertMp4ToWavAsync(string pathToMp4File);
    }
}
