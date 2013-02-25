using System.Text;
using Beauty.Business.Specs.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Beauty.Business.Specs
{
    public class BeautyFactory
    {
        private static readonly HtmlDocument GirlProfilePrototype;
        private enum BeautyProfileFieldIndex
        {
            Name = 2,
            Age = 4,
            Weight = 11
        }

        static BeautyFactory()
        {
            GirlProfilePrototype = new HtmlDocument();
            dynamic girlProfilePrototypeJson = JObject.Parse(Encoding.UTF8.GetString(Resources.GirlPrototype));
            GirlProfilePrototype.LoadHtml((string) girlProfilePrototypeJson.log.entries[0].response.content.text);
        }

        public Beauty Create(Weight weight)
        {
            var result = CreateBeautyPrototype();
            result.Weight = weight.Value;
            return result;
        }

        public Beauty Create(Age age)
        {
            var result = CreateBeautyPrototype();
            result.Age = age.Value;
            return result;
        }

        private Beauty CreateBeautyPrototype()
        {
            return new Beauty
                {
                    Name = GetProfileField(BeautyProfileFieldIndex.Name),
                    Age = int.Parse(GetProfileField(BeautyProfileFieldIndex.Age)),
                    Weight = int.Parse(GetProfileField(BeautyProfileFieldIndex.Weight))
                };
        }

        private static string GetProfileField(BeautyProfileFieldIndex profileFieldIndex)
        {
            return
                GirlProfilePrototype.DocumentNode.SelectSingleNode(string.Format(@"//html/body/table[3]//tr[{0}]/td[2]",
                                                                                 (int)profileFieldIndex)).InnerText;
        }
    }
}