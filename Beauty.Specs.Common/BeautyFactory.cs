using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Beauty.Business;
using Beauty.Specs.Common.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Beauty = Beauty.Business.Beauty;

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
            var beauty = Mapper.Map<BeautyProfile, Business.Beauty>(result);
            beauty.Id = _beautyCount++;
            return beauty;
        }

        public Business.Beauty Create(Age age)
        {
            var beauty = Mapper.Map<BeautyProfile, Business.Beauty>(CreateHtml(age));
            beauty.Id = _beautyCount;
            return beauty;
        }

        private BeautyProfile CreateBeautyPrototype()
        {
            var prototype = new HtmlDocument();
            prototype.LoadHtml((string) GirlProfilePrototype.log.entries[0].response.content.text);
            
            var profileUri = new Uri(String.Format("http://beauty.com/profile/{0}", _beautyCount++));
            return new BeautyProfile(prototype, profileUri);
        }

        public BeautyProfile CreateHtml(Age age)
        {
            var result = CreateBeautyPrototype();
            result.Age = age.Value;
            return result;
        }

        public IEnumerable<Business.Beauty> GenerateByAgeRange(int beautiesAmount, int ageFrom, int ageTo)
        {
            while (beautiesAmount != 0)
            {
                foreach (Age age in Enumerable.Range(ageFrom, ageTo - ageFrom))
                {
                    if (beautiesAmount == 0)
                    {
                        break;
                    }

                    yield return Create(age);
                    beautiesAmount--;
                }
            }
        }

        public BeautyProfile CreateHtml(Business.Beauty beautyPrototype)
        {
            var result = CreateBeautyPrototype();
            return Mapper.Map(beautyPrototype, result);
        }
    }
}