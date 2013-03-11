﻿using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;
using Beauty.Business.Dal;
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
            foreach (Age age in ages.ToArrayOf<int>())
            {
                siteBrowserMock.RegisterBeauty(age);
            }
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFromValue, int ageToValue)
        {
            var criterias = new List<Criteria>();
            AgeFrom ageFrom = ageFromValue;
            criterias.Add(ageFrom);

            AgeTo ageTo = ageToValue;
            criterias.Add(ageTo);

            ScenarioContext.Current.Set(criterias);
        }

        [Then(@"found girls should be age of (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            var repository = ObjectFactory.GetInstance<IBeautyRepository>();
            var criterias = ScenarioContext.Current.Get<List<Criteria>>();
            var actualAges = repository.Find(criterias).Select(x => x.Age);
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

        [Then(@"found girls should weight (.*)")]
        public void ThenFoundGirlsShouldWeight(string weight)
        {
            var repository = ObjectFactory.GetInstance<IBeautyRepository>();
            var criterias = ScenarioContext.Current.Get<List<Criteria>>();
            IEnumerable<int> actualAges = repository.Find(criterias).Select(x => x.Weight);
            actualAges.Should().BeEquivalentTo(weight.ToArrayOf<int>());
        }
    }
}