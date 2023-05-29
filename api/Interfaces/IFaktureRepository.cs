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
        void FakturaUpdate(ZaglavljeRacuna zaglavljeRacuna);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ZaglavljeRacuna>> GetFaktureAsync();
        Task<ZaglavljeRacuna> GetFakturuByBrojRacuna(int brojracuna);
    }
}