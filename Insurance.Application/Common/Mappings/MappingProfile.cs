using AutoMapper;
using Insurance.Domain.Entities;
using Insurance.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BenefitsDto, BenefitsDetail>()
                .ForMember(dest => dest.Benefits_Amount_Quotation, opt => opt.MapFrom(src => src.BenefitsAmountQuotation))
                .ForMember(dest => dest.Pended_Amount, opt => opt.MapFrom(src => src.PendedAmount));


            CreateMap<BenefitsDetail, BenefitsDetailDto>();

            CreateMap<Consumer, ConsumerBenefitsDto>()
                .ForMember(dest => dest.BenefitsDetails,
                            opt => opt.MapFrom(
                                src => src.BenefitsDetails));
        }
    }
}
