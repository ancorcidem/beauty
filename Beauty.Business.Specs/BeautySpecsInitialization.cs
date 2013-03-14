using System.Data.Entity;
using Beauty.Business.Dal;
using StructureMap;
using TechTalk.SpecFlow;

namespace Beauty.Business.Specs
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