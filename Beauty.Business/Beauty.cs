using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using AutoMapper;

namespace Beauty.Business
{
    public class Beauty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public Beauty()
        {
            GetAvatar = ConvertAvatarFromBlobToImage;
        }

        [NotMapped]
        public Uri Uri
        {
            get { return new Uri(Url); }
            set { Url = value.ToString(); }
        }

        public string Url { get; set; }

        private Image ConvertAvatarFromBlobToImage()
        {
            var bitmap = new Bitmap(new MemoryStream(AvatarImageBlob));
            GetAvatar = () => bitmap;
            return bitmap;
        }

        private Func<Image> GetAvatar;

        [NotMapped]
        public Image Avatar
        {
            get { return GetAvatar(); }
        }

        public byte[] AvatarImageBlob { get; set; }
    }
}