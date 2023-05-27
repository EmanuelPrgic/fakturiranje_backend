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
            CreateMap<ZaglavljeRacuna, ZaglavljeRacunaDto>();
            CreateMap<StavkeRacuna, StavkeRacunaDto>();
        }
    }
}