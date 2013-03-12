using AutoMapper;

namespace Beauty.UI.WinForms
{
    public class AutomapperProductionProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Business.Beauty, BeautyView>();
        }
    }
}