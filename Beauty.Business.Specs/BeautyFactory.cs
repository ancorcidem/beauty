using System.Text;
using Beauty.Business.Specs.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Beauty.Business.Specs
{
    public class BeautyFactory
    {
        private static readonly HtmlDocument GirlProfilePrototype;

        static BeautyFactory()
        {
            GirlProfilePrototype = new HtmlDocument();
            dynamic girlProfilePrototypeJson = JObject.Parse(Encoding.UTF8.GetString(Resources.GirlPrototype));
            GirlProfilePrototype.LoadHtml((string) girlProfilePrototypeJson.log.entries[0].response.content.text);
        }

        public Beauty Create(Weight weight)
        {
            return CreateHtml(weight);
        }

        public Beauty CreateHtml(Weight weight)
        {
            var result = CreateBeautyPrototype();
            result.Weight = weight.Value;
            return result;
        }

        public Beauty Create(Age age)
        {
            return CreateHtml(age);
        }

        private static BeautyProfile CreateBeautyPrototype()
        {
            return new BeautyProfile(GirlProfilePrototype);
        }

        public BeautyProfile CreateHtml(Age age)
        {
            var result = CreateBeautyPrototype();
            result.Age = age.Value;
            return result;
        }
    }
}