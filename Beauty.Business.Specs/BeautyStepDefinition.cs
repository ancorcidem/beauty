using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;
using FluentAssertions;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business
{
    [Binding]
    public class BeautyStepDefinition
    {
        [Given(@"beauties aging (.*)")]
        public void GivenBeautiesAging(string ages)
        {
            var siteBrowserMock = ObjectFactory.GetInstance<SiteBrowserMock>();
            foreach (Age age in ages.ToArrayOf<int>())
            {
                siteBrowserMock.RegisterBeauty(age);
            }
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFromValue, int ageToValue)
        {
            ScenarioContext.Current.Set(new List<BeautyFoundMessage>());
            var bus = ObjectFactory.GetInstance<IBus>();
            bus.Subscribe<BeautyFoundMessage>(x => ScenarioContext.Current.Get<List<BeautyFoundMessage>>().Add(x));

            var filter = ObjectFactory.GetInstance<IBeautyFilter>();

            filter.Filter = new Criteria[] { (AgeFrom)ageFromValue, (AgeTo)ageToValue };
        }

        [Then(@"found girls should be age of (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            var actualAges = ScenarioContext.Current.Get<List<BeautyFoundMessage>>().SelectMany(x => x.Beauties).Select(x => x.Age);
            actualAges.Should().BeEquivalentTo(ages.ToArrayOf<int>());
        }

        [When(@"search for beauty who weight between (.*) and (.*) kg")]
        public void WhenSearchForBeautyWhoWeightBetweenAndKg(int weightFromValue, int weightToValue)
        {
            var criterias = ObjectFactory.GetInstance<List<Criteria>>();
            WeightFrom weightFrom = (Weight) weightFromValue;
            criterias.Add(weightFrom);

            WeightTo weightTo = (Weight) weightToValue;
            criterias.Add(weightTo);

            ScenarioContext.Current.Set(criterias);
        }
    }
}