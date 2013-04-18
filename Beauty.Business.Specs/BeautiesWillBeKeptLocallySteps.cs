using System;
using System.Collections.Generic;
using System.Linq;
using Beauty.Business.Criterias;
using Beauty.Business.Dal;
using Beauty.Business.ServiceBus;
using FluentAssertions;
using StructureMap;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Beauty.Business
{
    [Binding]
    public class BeautiesWillBeKeptLocallySteps
    {
        [Given(@"beauty already found:")]
        public void GivenBeautyAlreadyFound(Table table)
        {
            var beauties = table.CreateSet<Beauty>();

            var sqlRepository = ObjectFactory.GetInstance<BeautySqlRepository>();
            sqlRepository.Add(beauties.ToArray());
        }

        [Given(@"beauty on site:")]
        public void GivenBeautyOnSite(Table table)
        {
            var siteBrowser = ObjectFactory.GetInstance<SiteBrowserMock>();
            siteBrowser.Register(table.CreateSet<Beauty>());
        }

        [Then(@"found girls should be:")]
        public void ThenFoundGirlsShouldBe(Table table)
        {
            var beautiesExpected = table.CreateSet<Beauty>();

            var beautiesFound = ScenarioContext.Current.Get<List<BeautyFoundMessage>>().SelectMany(x => x.Beauties);
            beautiesFound.Select(x => x.Url).Should().BeEquivalentTo(beautiesExpected.Select(x => x.Url));
        }

    }
}