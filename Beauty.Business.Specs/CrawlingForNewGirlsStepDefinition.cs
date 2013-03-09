using System;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business.Specs
{
    [Binding]
    public class CrawlingForNewGirlsStepDefinition
    {
        [Given(@"some beauties who present on site only with age (.*)")]
        public void GivenSomeBeautiesWhoPresentOnSiteOnlyWithAge(string agesOnSite)
        {
            var siteBrowser = ObjectFactory.GetInstance<SiteBrowserMock>();
            var ages = agesOnSite.ToArrayOf<int>();
            foreach (Age age in ages)
            {
                siteBrowser.RegisterBeauty(age);
            }
        }

        [Given(@"some beauties who present on site only with weight (.*)")]
        public void GivenSomeBeautiesWhoPresentOnSiteOnlyWithWeightWeight(string weightsOnSite)
        {
            ScenarioContext.Current.Pending();
        }

        //[Then(@"girls found on site should have age (.*)")]
        //public void ThenGirlsFoundOnSiteShouldHaveAge(string agesFoundOnSite)
        //{
        //    IEnumerable<int> actualAges = ScenarioContext.Current.Get<CriteriaCollection>().Find().Select(x => x.Age);
        //    actualAges.Should().BeEquivalentTo(agesFoundOnSite.ToArrayOf<int>());
        //    //siteBrowser.AssertWasCalled(x => )
        //}

        [Then(@"girls found on site should have weight (.*)")]
        public void ThenGirlsFoundOnSiteShouldHaveWeight(string weightFoundOnSite)
        {
            ScenarioContext.Current.Pending();
        }
    }
}