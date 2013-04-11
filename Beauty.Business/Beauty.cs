using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace Beauty.Business
{
    public class Beauty : IEquatable<Beauty>
    {
        public bool Equals(Beauty other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Name, other.Name) && Age == other.Age && Weight == other.Weight && string.Equals(Url, other.Url);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Beauty) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id;
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Age;
                hashCode = (hashCode*397) ^ Weight;
                hashCode = (hashCode*397) ^ (Url != null ? Url.GetHashCode() : 0);
                return hashCode;
            }
        }

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

        [MaxLength]
        public byte[] AvatarImageBlob { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, {1}, {2} y.o.", Id, Name, Age);
        }
    }
}