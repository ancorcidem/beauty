using System;
using System.Linq;
using Beauty.Business;
using FluentAssertions;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Specs.UI.StepDefinitions
{
    [Binding]
    public class BeautyStepDefinition
    {
        [Given(@"beauties aging (.*)")]
        public void GivenBeautiesAging(string ages)
        {
            var context = ObjectFactory.GetInstance<IBeautyRepository>();
            foreach (var age in ages.ToArrayOf<int>())
            {
                context.Beauties.Add(new Business.Beauty {Name = string.Format("Beauty {0}", age), Age = age});
            }
            context.SaveChanges();
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int ageFrom, int ageTo)
        {
            var criterias = ObjectFactory.GetInstance<CriteriaCollection>();
            //criterias.Add(beauty => beauty.Age >= ageFrom && beauty.Age <= ageTo);
            
            criterias.Add(beauty => beauty.Age >= ageFrom);
            criterias.Add(beauty => beauty.Age <= ageTo);

            ScenarioContext.Current.Set(criterias);
        }

        [Then(@"found girls should be (.*)")]
        public void ThenFoundGirlsShouldBe(string ages)
        {
            ScenarioContext.Current.Get<CriteriaCollection>().Find()
                           .Select(x => x.Age)
                           .Should()
                           .BeEquivalentTo(ages.ToArrayOf<int>());
        }
    }
}