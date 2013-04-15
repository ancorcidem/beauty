using System.Data.Entity;
using AutoMapper;
using Beauty.Business.Dal;
using Beauty.Business.StructureMap;
using Beauty.Specs.Common;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business
{
    [Binding]
    public class BeautySpecsInitialization
    {
        [BeforeScenario]
        public void Init()
        {
            Database.SetInitializer(new BeautyDbInitializer());

            var context = new BeautyDbContext();
            context.Database.Initialize(true);

            ObjectFactory.Initialize(x => x.AddRegistry<BusinessSpecsRegistry>());
            Mapper.AddProfile<ProductionAutoMapperProfile>();
            Mapper.AddProfile<SpecsCommonAutoMapperProfile>();
        }
    }
}