using TechTalk.SpecFlow;

namespace Beauty.Specs.UI.StepDefinitions
{
    [Binding]
    public class BeautyStepDefinition
    {
        [Given(@"beauties aging (.*), (.*), (.*), (.*)")]
        public void GivenBeautiesAging(int p0, int p1, int p2, int p3)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"search for a beauty between (.*) and (.*) years old")]
        public void WhenSearchForABeautyBetweenAndYearsOld(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"found girls should be (.*), (.*)")]
        public void ThenFoundGirlsShouldBe(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}