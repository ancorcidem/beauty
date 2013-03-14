using AutoMapper;

namespace Beauty.Business
{
    public class ProductionAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<BeautyProfile, Beauty>()
                .ForMember(x => x.Url, expression => expression.MapFrom(y => y.Uri.ToString()))
                .ForMember(x => x.Uri, expression => expression.Ignore())
                .ForMember(x => x.Id, expression => expression.Ignore());
        }
    }
}