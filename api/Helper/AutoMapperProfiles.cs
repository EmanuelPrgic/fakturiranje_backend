using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using AutoMapper;
using api.Entities;

namespace api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Partner, PartnerDto>();
            CreateMap<PartnerDto, Partner>();
            CreateMap<ZaglavljeRacuna, ZaglavljeRacunaDto>();
            CreateMap<ZaglavljeRacunaDto, ZaglavljeRacuna>();
            CreateMap<StavkeRacuna, StavkeRacunaDto>();
            CreateMap<StavkeRacunaDto, StavkeRacuna>();
            CreateMap<StavkeRacuna, UslugaUpdateDto>();
            CreateMap<UslugaUpdateDto, StavkeRacuna>();
        }
    }
}