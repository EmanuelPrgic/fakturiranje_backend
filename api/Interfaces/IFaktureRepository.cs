using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Entities;

namespace api.Interfaces
{
    public interface IFaktureRepository
    {
        Task<bool> FakturaUpdate(int id, ZaglavljeRacunaDto zaglavljeRacunaDto);
        Task<bool> FakturaDelete(int id);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ZaglavljeRacuna>> GetFaktureAsync();
        Task<ZaglavljeRacuna> GetFakturuByBrojRacuna(int brojracuna);
        Task<ZaglavljeRacuna> GetFakturuById(int id);
        Task<ZaglavljeRacunaDto> AddFakturu(ZaglavljeRacunaDto zaglavljeRacunaDto);
    }
}