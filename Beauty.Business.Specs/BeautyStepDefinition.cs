using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beauty.Business.Specs.Properties;
using Beauty.Specs.Common;
using CsQuery;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business.Specs
{
    [Binding]
    public class BeautyStepDefinition
    {
        [Given(@"beauties aging (.*)")]
        public void GivenBeautiesAging(string ages)
        {
            var context = ObjectFactory.GetInstance<IBeautyRepository>();

            dynamic girlProfilePrototype = JObject.Parse(Encoding.UTF8.GetString(Resources.GirlPrototype));
            CQ profile = CQ.Create(girlProfilePrototype.log.entries[0].response.content.text);
            profile.Select("html body table tbody tr td table tbody tr td");

            //prototype.log.entries[0].response.content.text
            //string response = prototype.entries.response;



            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (var age in ages.ToArrayOf<int>())
            {
                context.Beauties.Add(factory.Create(age));
            }
            context.SaveChanges();
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFromValue, int ageToValue)
        {
            var criterias = ObjectFactory.GetInstance<CriteriaCollection>();
            AgeFrom ageFrom = ageFromValue;
            criterias.Add(ageFrom);

            AgeTo ageTo = ageToValue;
            criterias.Add(ageTo);

            ScenarioContext.Current.Set(criterias);
        }

        [Then(@"found girls should be (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            IEnumerable<int> actualAges = ScenarioContext.Current.Get<CriteriaCollection>().Find().Select(x => x.Age);
            actualAges.Should().BeEquivalentTo(ages.ToArrayOf<int>());
        }

        [Given(@"beauties who weight (.*)")]
        public void GivenBeautiesWhoWeight(string weights)
        {
            var context = ObjectFactory.GetInstance<IBeautyRepository>();
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (Weight weight in weights.ToArrayOf<int>())
            {
                context.Beauties.Add(factory.Create(weight));
            }
        }

        [When(@"search for beauty who weight between (.*) and (.*) kg")]
        public void WhenSearchForBeautyWhoWeightBetweenAndKg(int weightFromValue, int weightToValue)
        {
            var criterias = ObjectFactory.GetInstance<CriteriaCollection>();
            WeightFrom weightFrom = (Weight) weightFromValue;
            criterias.Add(weightFrom);

            WeightTo weightTo = (Weight) weightToValue;
            criterias.Add(weightTo);

            ScenarioContext.Current.Set(criterias);
        }

        [Then(@"found girls should weight (.*)")]
        public void ThenFoundGirlsShouldWeight(string weight)
        {
            IEnumerable<int> actualAges = ScenarioContext.Current.Get<CriteriaCollection>().Find().Select(x => x.Weight);
            actualAges.Should().BeEquivalentTo(weight.ToArrayOf<int>());
        }
    }
}