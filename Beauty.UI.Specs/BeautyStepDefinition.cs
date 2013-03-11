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
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<BeautyRepositoryPresenter>());

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
            var beauties = ShownBeauties();

            var context = ObjectFactory.GetInstance<BeautyMockRepository>();
            var result = context.Find(context.UsedCriterias);
            beauties.Should().BeEquivalentTo(result);
        }

        [Given(@"(.*) beauties aging from (.*) to (.*)")]
        public void GivenBeautiesAgingFromTo(int beautiesAmount, int ageFrom, int ageTo)
        {
            var context = ObjectFactory.GetInstance<BeautyMockRepository>();
            var factory = ObjectFactory.GetInstance<BeautyFactory>();
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<BeautyRepositoryPresenter>());
            while (beautiesAmount != 0)
            {
                foreach (Age age in Enumerable.Range(ageFrom, ageTo - ageFrom))
                {
                    if (beautiesAmount == 0)
                    {
                        break;
                    }

                    context.Add(factory.Create(age));
                    beautiesAmount--;
                }
            }
        }

        private static IEnumerable<Business.Beauty> ShownBeauties()
        {
            var view = ObjectFactory.GetInstance<IMainView>();
            var shownBeauties = (BeautyViewModel) view.GetArgumentsForCallsMadeOn(x => x.Show(null)).Single()[0];
            return shownBeauties.Beauties;
        }

        [Then(@"all (.*) beauties should be found")]
        public void ThenAllBeautiesShouldBeFound(int beautiesAmountToFind)
        {
            ShownBeauties().Count().Should().Be(beautiesAmountToFind);
        }
    }
}