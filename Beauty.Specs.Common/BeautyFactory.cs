using System;
using System.Text;
using AutoMapper;
using Beauty.Business;
using Beauty.Specs.Common.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace Beauty.Specs.Common
{
    public class BeautyFactory
    {
        private static readonly dynamic GirlProfilePrototype;
        private int _beautyCount;

        static BeautyFactory()
        {
            GirlProfilePrototype = JObject.Parse(Encoding.UTF8.GetString(Resources.GirlPrototype));
        }

        public Business.Beauty Create(Weight weight)
        {
            return CreateHtml(weight);
        }

        public Business.Beauty CreateHtml(Weight weight)
        {
            var result = CreateBeautyPrototype();
            result.Weight = weight.Value;
            return Mapper.Map<BeautyProfile, Business.Beauty>(result);
            ;
        }

        public Business.Beauty Create(Age age)
        {
            return Mapper.Map<BeautyProfile, Business.Beauty>(CreateHtml(age));
        }

        private BeautyProfile CreateBeautyPrototype()
        {
            var prototype = new HtmlDocument();
            prototype.LoadHtml((string) GirlProfilePrototype.log.entries[0].response.content.text);
            
            var profileUri = new Uri(string.Format("http://beauty.com/profile/{0}", _beautyCount++));
            return new BeautyProfile(prototype, profileUri);
        }

        public BeautyProfile CreateHtml(Age age)
        {
            var result = CreateBeautyPrototype();
            result.Age = age.Value;
            return result;
        }
    }
}