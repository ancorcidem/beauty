using System.Data.Entity;
using Beauty.Business.Dal;
using Beauty.Business.StructureMap;
using StructureMap;
using TechTalk.SpecFlow;
using BeautyDbInitializer = Beauty.Business.Specs.BeautyDbInitializer;

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
            AutoMapper.Mapper.AddProfile<ProductionAutoMapperProfile>();
        }
    }
}