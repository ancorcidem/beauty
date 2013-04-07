using Beauty.Business;

namespace Beauty.UI.WinForms
{
    public class AutoMapperProductionProfile : ProductionAutoMapperProfile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<Business.Beauty, BeautyViewModel>()
                .ForMember(x => x.Profile, opt => opt.MapFrom(x => x.Uri));
        }
    }
}