using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Beauty.Business.Dal;

namespace Beauty.Specs.Common.Mocks
{
    public class ImageDownloaderMock : IImageDownloader
    {
        private static readonly byte[] _download;

        static ImageDownloaderMock()
        {
            var emptyBitmap = new Bitmap(100, 100);
            var memoryStream = new MemoryStream();
            emptyBitmap.Save(memoryStream, ImageFormat.Jpeg);
            _download = memoryStream.ToArray();
        }

        public byte[] Download(Uri address)
        {
            return _download;
        }
    }
}