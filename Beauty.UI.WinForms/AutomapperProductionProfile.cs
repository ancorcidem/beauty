using AutoMapper;

namespace Beauty.UI.WinForms
{
    public class AutoMapperProductionProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Business.Beauty, BeautyView>().ForMember(x => x.Profile, opt => opt.MapFrom(x => x.Uri));
        }
    }
}