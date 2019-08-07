using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blip.Api.AudioProcessor.Services
{
    public class MediaDownloader : IMediaDownloader
    {
        private const string DOWNLOADED_FILE_PATH_TPL = @"{0}\\audio_{1}.mp4";

        public string DownloadFromUri(string uri)
        {
            var now = DateTime.Now;
            var downloadedFilePath = string.Format(DOWNLOADED_FILE_PATH_TPL, Path.GetTempPath(), now.ToFileTime());

            // Download media from uri
            var client = new WebClient();
            client.DownloadFile(uri, downloadedFilePath);
            return downloadedFilePath;
        }
    }
}
