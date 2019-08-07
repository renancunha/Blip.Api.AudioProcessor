using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FFmpeg.NET;
using Microsoft.Extensions.Hosting;

namespace Blip.Api.AudioProcessor.Services
{
    public class MediaConversor : IMediaConversor
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public MediaConversor(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            
        }

        private const string CONVERTED_FILE_PATH_TPL = @"{0}\\audio_{1}_converted.{2}";

        public async Task<string> ConvertMp4ToWavAsync(string pathToMp4File)
        {
            var now = DateTime.Now;
            var convertedFilePath = string.Format(CONVERTED_FILE_PATH_TPL, Path.GetTempPath(), now.ToFileTime(), "wav");

            var inputFile = new MediaFile(pathToMp4File);
            var outputFile = new MediaFile(convertedFilePath);

            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var ffmpegPath = $"{directory}\\ffmpeg.exe";

            var ffmpeg = new Engine(ffmpegPath);
            await ffmpeg.ConvertAsync(inputFile, outputFile);

            return convertedFilePath;
        }
    }
}
