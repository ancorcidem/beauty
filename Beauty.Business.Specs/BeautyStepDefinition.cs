using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;
using FluentAssertions;
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
            var siteBrowserMock = ObjectFactory.GetInstance<SiteBrowserMock>();

            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (Age age in ages.ToArrayOf<int>())
            {
                siteBrowserMock.RegisterBeauty(age);
            }
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

        [Then(@"found girls should be age of (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            var actualAges = ScenarioContext.Current.Get<CriteriaCollection>().Find().Select(x => x.Age);
            actualAges.Should().BeEquivalentTo(ages.ToArrayOf<int>());
        }

        [Given(@"beauties who weight (.*)")]
        public void GivenBeautiesWhoWeight(string weights)
        {
            ScenarioContext.Current.Pending();
            //var context = ObjectFactory.GetInstance<IBeautyRepository>();
            //var factory = ObjectFactory.GetInstance<BeautyFactory>();
            //foreach (Weight weight in weights.ToArrayOf<int>())
            //{
            //    context.Add(factory.Create(weight));
            //}
            //context.Commit();
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