using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using Beauty.Business.Dal;
using HtmlAgilityPack;

namespace Beauty.Business
{
    public class BeautyProfile
    {
        private readonly HtmlDocument _html;
        public Uri Uri { get; private set; }

        private enum BeautyProfileFieldIndex
        {
            Name = 2,
            Age = 4,
            Weight = 11
        }

        public BeautyProfile(HtmlDocument html, Uri uri)
        {
            _html = html;
            Uri = uri;
            LoadAvatarImageBlob = LoadAvatarImageBlobViaHttp;
        }

        public BeautyProfile(string girlProfileHtml)
        {
            _html = new HtmlDocument();
            _html.LoadHtml(girlProfileHtml);
        }

        private HtmlNode GetProfileFieldValue(BeautyProfileFieldIndex profileFieldIndex)
        {
            return
                _html.DocumentNode.SelectSingleNode(
                    String.Format(@"//html/body/table[3]//tr[{0}]/td[2]",
                                  (int) profileFieldIndex));
        }

        public string Name
        {
            get { return GetProfileFieldValue(BeautyProfileFieldIndex.Name).InnerHtml; }
            set { GetProfileFieldValue(BeautyProfileFieldIndex.Name).InnerHtml = value; }
        }

        public int Age
        {
            get { return Int32.Parse(GetProfileFieldValue(BeautyProfileFieldIndex.Age).InnerHtml); }
            set
            {
                GetProfileFieldValue(BeautyProfileFieldIndex.Age).InnerHtml =
                    value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public int Weight
        {
            get { return Int32.Parse(GetProfileFieldValue(BeautyProfileFieldIndex.Weight).InnerHtml); }
            set
            {
                GetProfileFieldValue(BeautyProfileFieldIndex.Weight).InnerHtml =
                    value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private static readonly byte[] EmptyImage;

        static BeautyProfile()
        {
            using (var bitmap = new Bitmap(100, 100))
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    EmptyImage = stream.ToArray();
                }
            }
        }

        private byte[] LoadAvatarImageBlobViaHttp()
        {
            HtmlNode imageNode = _html.DocumentNode.SelectSingleNode(@"//html/body/table[3]//img");
            if (imageNode == null)
            {
                return EmptyImage;
            }
            var avatarUrl = new Uri(SiteBrowser.BaseUri, imageNode.Attributes["src"].Value);

            byte[] result = avatarUrl.DownloadImage();
            LoadAvatarImageBlob = () => result;
            return result;
        }

        private Func<byte[]> LoadAvatarImageBlob;

        public byte[] AvatarImageBlob
        {
            get { return LoadAvatarImageBlob(); }
        }
    }
}