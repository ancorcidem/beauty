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
    }
}