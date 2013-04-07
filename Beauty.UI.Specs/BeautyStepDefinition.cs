using System;
using System.Linq;
using Beauty.Business;
using Beauty.Business.Criterias;
using Beauty.Business.ServiceBus;
using Beauty.Specs.Common;
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
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<BeautyMainViewPresenter>());

            foreach (Age age in ages.ToArrayOf<int>())
            {
                Repository.Add(Factory.Create(age));
            }
        }

        [StepDefinition(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFromValue, int ageToValue)
        {
            var view = ObjectFactory.GetInstance<IFilterView>();

            var viewModel = new SearchParameters
                {
                    AgeFrom = ageFromValue,
                    AgeTo = ageToValue
                };

            ScenarioContext.Current.Set(viewModel);

            view.Raise(x => x.FilterChanged += null, view, new FilterChangeEventArgs(viewModel));
        }

        [Then(@"found girls should be age of (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            var agesOnStage = ObjectFactory.GetInstance<BeautyGroupViewMock>().BeautiesOnTheStage.Select(x => x.Age);
            agesOnStage.Should().BeEquivalentTo(ages.ToArrayOf<int>().Select(x => (Age) x));
        }

        [Given(@"(.*) beauties aging from (.*) to (.*)")]
        public void GivenBeautiesAgingFromTo(int beautiesAmount, int ageFrom, int ageTo)
        {
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<BeautyMainViewPresenter>());

            var beautiesToAdd = Factory.GenerateByAgeRange(beautiesAmount, ageFrom, ageTo);

            Repository.Add(beautiesToAdd.ToArray());
        }

        private static BeautyMockRepository Repository
        {
            get { return ObjectFactory.GetInstance<BeautyMockRepository>(); }
        }

        private static BeautyFactory Factory
        {
            get { return ObjectFactory.GetInstance<BeautyFactory>(); }
        }

        [When(@"a new beauty aging (.*) added on site")]
        public void WhenANewBeautyAgingAddedOnSite(int beautyAge)
        {
            Age age = beautyAge;
            Business.Beauty beauty = Factory.Create(age);
            Repository.Add(beauty);

            var beautyDataFeed = ObjectFactory.GetInstance<IBus>();

            beautyDataFeed.Publish(new BeautyFoundMessage
                {
                    Beauties = new[] {beauty},
                    Criterias = new Criteria[] {(AgeFrom) beautyAge, (AgeTo) beautyAge}
                });
        }

        [Then(@"the new beauty aging (.*) should be found")]
        public void ThenTheNewBeautyAgingShouldBeFound(int age)
        {
            var shownBeautyAges = ObjectFactory.GetInstance<BeautyGroupViewMock>().BeautiesOnTheStage.Select(x => x.Age);
            shownBeautyAges.Contains(age).Should().Be(true, "age {0} not found", age);
        }


        [Then(@"all (.*) beauties should be found")]
        public void ThenAllBeautiesShouldBeFound(int beautiesAmountToFind)
        {
            ObjectFactory.GetInstance<BeautyGroupViewMock>().BeautiesOnTheStage.Length
                         .Should()
                         .Be(beautiesAmountToFind);
        }
    }
}