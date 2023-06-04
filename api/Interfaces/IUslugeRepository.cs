using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Entities;

namespace api.Interfaces
{
    public interface IUslugeRepository
    {
        Task<bool> UslugaUpdate(int id, UslugaUpdateDto uslugaUpdateDto);
        Task<bool> UslugaDelete(int id);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<StavkeRacuna>> GetUslugeAsync();
        Task<StavkeRacuna> GetUsluguById(int id);
        Task<StavkeRacunaDto> AddUslugu(StavkeRacunaDto stavkeRacunaDto);
        Task<StavkeRacuna> CalculateVrijednostiAsync(int id);
    }
}