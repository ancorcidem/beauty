using System;
using System.Net;

namespace Beauty.Business.Dal
{
    public class ImageDownloader : IImageDownloader
    {
        public byte[] Download(Uri address)
        {
            return new WebClient().DownloadData(address);
        }
    }
}