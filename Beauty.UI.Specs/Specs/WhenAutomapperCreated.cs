using AutoMapper;
using Beauty.UI.WinForms;
using NUnit.Framework;

namespace Beauty.UI.Specs.Specs
{
    [TestFixture]
    public class WhenAutomapperCreated
    {
        [Test]
        public void ItShouldBeValid()
        {
            Mapper.Initialize(x => x.AddProfile<AutoMapperProductionProfile>());

            Mapper.AssertConfigurationIsValid();
        }
    }
}