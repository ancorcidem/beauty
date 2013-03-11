using System;

namespace Beauty.Business
{
    public interface IBeautyDataFeed
    {
        event EventHandler<BeautyFoundEventArgs> Found;
    }
}