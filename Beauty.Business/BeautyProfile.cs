using System;
using System.Globalization;
using HtmlAgilityPack;

namespace Beauty.Business
{
    public class BeautyProfile
    {
        private readonly HtmlDocument _girlProfileHtmlDocument;

        private enum BeautyProfileFieldIndex
        {
            Name = 2,
            Age = 4,
            Weight = 11
        }

        public BeautyProfile(HtmlDocument girlProfileHtmlDocument)
        {
            _girlProfileHtmlDocument = girlProfileHtmlDocument;
        }

        public BeautyProfile(string girlProfileHtml)
        {
            _girlProfileHtmlDocument = new HtmlDocument();
            _girlProfileHtmlDocument.LoadHtml(girlProfileHtml);

        }

        private HtmlNode GetProfileFieldValue(BeautyProfileFieldIndex profileFieldIndex)
        {
            return
                _girlProfileHtmlDocument.DocumentNode.SelectSingleNode(
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