﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18033
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Beauty.Business.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("beauties will be kept locally")]
    public partial class BeautiesWillBeKeptLocallyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BuildOurOwnProfileDatabase.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "beauties will be kept locally", "In order to not to be fooled by changed profile\r\nAs a man\r\nI want to see beauty c" +
                    "hange history", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("add beauty only once")]
        public virtual void AddBeautyOnlyOnce()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("add beauty only once", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "url",
                        "name",
                        "age"});
            table1.AddRow(new string[] {
                        "http://intimby.net/profile1",
                        "Anita",
                        "19"});
#line 8
 testRunner.Given("beauty already found:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "url",
                        "name",
                        "age"});
            table2.AddRow(new string[] {
                        "http://intimby.net/profile1",
                        "Anita",
                        "19"});
#line 11
  testRunner.And("beauty on site:", ((string)(null)), table2, "And ");
#line 14
 testRunner.When("search for a beauty between 19 and 19 years old", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "url",
                        "name",
                        "age"});
            table3.AddRow(new string[] {
                        "http://intimby.net/profile1",
                        "Anita",
                        "19"});
#line 15
 testRunner.Then("found girls should be:", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("update beauty previously found when matched by profile url")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void UpdateBeautyPreviouslyFoundWhenMatchedByProfileUrl()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("update beauty previously found when matched by profile url", new string[] {
                        "ignore"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "url",
                        "name",
                        "age"});
            table4.AddRow(new string[] {
                        "1",
                        "http://intimby.net/profile1",
                        "Anita",
                        "19"});
#line 21
 testRunner.Given("beauty already found:", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "url",
                        "name",
                        "age"});
            table5.AddRow(new string[] {
                        "http://intimby.net/profile1",
                        "Marina",
                        "28"});
#line 24
  testRunner.And("beauty on site:", ((string)(null)), table5, "And ");
#line 27
 testRunner.When("search for a beauty between 18 and 28 years old", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "name"});
            table6.AddRow(new string[] {
                        "Anita"});
            table6.AddRow(new string[] {
                        "Marina"});
#line 28
 testRunner.Then("beauty with id = 1 will have name change history:", ((string)(null)), table6, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "age",
                        "name"});
            table7.AddRow(new string[] {
                        "19",
                        "Anita"});
            table7.AddRow(new string[] {
                        "28",
                        "Marina"});
#line 32
  testRunner.And("beauty with id = 1 will have age change history:", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
