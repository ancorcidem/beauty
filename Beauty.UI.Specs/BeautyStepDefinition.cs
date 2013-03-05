using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business;
using Beauty.UI.WinForms;
using FluentAssertions;
using Rhino.Mocks;
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
            var context = ObjectFactory.GetInstance<BeautyMockRepository>();
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<MainFormController>());

            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (Age age in ages.ToArrayOf<int>())
            {
                context.Add(factory.Create(age));
            }
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFromValue, int ageToValue)
        {
            var view = ObjectFactory.GetInstance<IMainView>();

            var viewModel = new SearchParameters
                {
                    AgeFrom = ageFromValue,
                    AgeTo = ageToValue
                };

            ScenarioContext.Current.Set(viewModel);

            view.Raise(x => x.SearchButtonPressed += null, view, new SearchButtonPressEventArgs(viewModel));
        }

        [Then(@"found girls should be age of (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            var view = ObjectFactory.GetInstance<IMainView>();


            var context = ObjectFactory.GetInstance<BeautyMockRepository>();
            var result = context.Find(context.UsedCriterias);

            var shownBeauties = (BeautyViewModel) view.GetArgumentsForCallsMadeOn(x => x.Show(null)).Single()[0];
            shownBeauties.Beauties.Should().BeEquivalentTo(result);
        }

        [Given(@"beauties who weight (.*)")]
        public void GivenBeautiesWhoWeight(string weights)
        {
            var context = ObjectFactory.GetInstance<BeautyMockRepository>();
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<MainFormController>());

            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            foreach (Weight weight in weights.ToArrayOf<int>())
            {
                context.Add(factory.Create(weight));
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