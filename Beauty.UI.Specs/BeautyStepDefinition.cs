using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Beauty.Business;
using Beauty.Specs.Common;
using FluentAssertions;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.UI.Specs
{
    [Binding]
    public class BeautyStepDefinition
    {
        [Given(@"beauties aging (.*)")]
        public void GivenBeautiesAging(string ages)
        {
            var context = ObjectFactory.GetInstance<IBeautyRepository>();

            var factrory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (var age in ages.ToArrayOf<int>())
            {
                context.Beauties.Add(factrory.Create(age));
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
            WeightFrom weightFrom = (Weight)weightFromValue;
            criterias.Add(weightFrom);

            WeightTo weightTo = (Weight)weightToValue;
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

    public class WeightTo : Criteria
    {
        private readonly Weight _weight;

        private WeightTo(Weight weight)
        {
            _weight = weight;
        }

        public static implicit operator WeightTo(Weight weight)
        {
            return new WeightTo(weight);
        }

        protected override Expression<Func<Business.Beauty, bool>> Expression
        {
            get { return beauty => beauty.Weight <= _weight.Value; }
        }
    }
}