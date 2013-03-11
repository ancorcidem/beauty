using System;
using Beauty.Business.Criterias;

namespace Beauty.Business
{
    public class BeautyFoundEventArgs : EventArgs
    {
        public Criteria[] Criterias { get; set; }

        public Business.Beauty[] Beauties { get; set; }
    }
}