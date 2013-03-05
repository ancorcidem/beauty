using System;
using System.Globalization;
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
    }
}