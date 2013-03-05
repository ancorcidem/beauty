using System;
using System.Text;
using Beauty.Business.Specs.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Beauty.Business.Specs
{
    public class BeautyFactory
    {
        private static readonly dynamic GirlProfilePrototype;

        static BeautyFactory()
        {
            GirlProfilePrototype = JObject.Parse(Encoding.UTF8.GetString(Resources.GirlPrototype));
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
            var prototype = new HtmlDocument();
            prototype.LoadHtml((string) GirlProfilePrototype.log.entries[0].response.content.text);
            return new BeautyProfile(prototype, new Uri("http://beauty.com/"));
        }

        public BeautyProfile CreateHtml(Age age)
        {
            var result = CreateBeautyPrototype();
            result.Age = age.Value;
            return result;
        }
    }
}