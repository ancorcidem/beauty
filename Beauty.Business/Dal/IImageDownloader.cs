using System;

namespace Beauty.Business.Dal
{
    public interface IImageDownloader
    {
        byte[] Download(Uri address);
    }
}