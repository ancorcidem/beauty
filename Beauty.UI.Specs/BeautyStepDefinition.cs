using System;
using System.Collections.Generic;
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
            var view = ObjectFactory.GetInstance<IMainView>();

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
            var beauties = ShowBeautyCalls();

            var bus = ObjectFactory.GetInstance<IBus>();
            var result = new string[]{};
            bus.Subscribe<BeautyFoundMessage>(msg => result = msg.Beauties.Select(x => x.Name).ToArray());
            
            Repository.Find(Repository.UsedCriterias);
            beauties.Single().Beauties.Select(x => x.Name).Should().BeEquivalentTo(result);
        }

        [Given(@"(.*) beauties aging from (.*) to (.*)")]
        public void GivenBeautiesAgingFromTo(int beautiesAmount, int ageFrom, int ageTo)
        {
            ScenarioContext.Current.Set(ObjectFactory.GetInstance<BeautyMainViewPresenter>());
            while (beautiesAmount != 0)
            {
                foreach (Age age in Enumerable.Range(ageFrom, ageTo - ageFrom))
                {
                    if (beautiesAmount == 0)
                    {
                        break;
                    }

                    Repository.Add(Factory.Create(age));
                    beautiesAmount--;
                }
            }
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
            ShowBeautyCalls().Last().Beauties.Select(x => x.Age == age).Should().NotBeEmpty("age {0} not found", age);
        }


        private static IEnumerable<MainFormViewModel> ShowBeautyCalls()
        {
            var view = ObjectFactory.GetInstance<IMainView>();
            IEnumerable<MainFormViewModel> shownBeauties =
                view.GetArgumentsForCallsMadeOn(x => x.Show(null)).Select(x => (MainFormViewModel) x[0]);
            return shownBeauties;
        }

        [Then(@"all (.*) beauties should be found")]
        public void ThenAllBeautiesShouldBeFound(int beautiesAmountToFind)
        {
            ShowBeautyCalls().Single().Beauties.Count().Should().Be(beautiesAmountToFind);
        }
    }
}