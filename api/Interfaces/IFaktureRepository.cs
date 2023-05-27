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
        void ZaglavljeUpdate(ZaglavljeRacuna zaglavljeRacuna);
        void StavkeUpdate(StavkeRacuna stavkeRacuna);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ZaglavljeRacuna>> GetZaglavljaAsync();
        Task<IEnumerable<StavkeRacuna>> GetStavkeAsync();
        Task<ZaglavljeRacuna> GetZaglavljeByBrojRacuna(int brojRacuna);
        Task<ZaglavljeRacuna> GetZaglavljeById(int id);
        Task<StavkeRacuna> GetStavkeById(int id);
    }
}