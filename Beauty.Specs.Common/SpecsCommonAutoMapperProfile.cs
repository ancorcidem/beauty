using AutoMapper;
using Beauty.Business;

namespace Beauty.Specs.Common
{
    public class SpecsCommonAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Business.Beauty, BeautyProfile>()
                .ForMember(x => x.Uri, expression => expression.MapFrom(y => y.Uri.ToString()));
        }
    }
}