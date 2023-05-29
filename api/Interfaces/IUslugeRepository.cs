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
        void UslugaUpdate(StavkeRacuna stavkeRacuna);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<StavkeRacuna>> GetUslugeAsync();
        Task<StavkeRacuna> GetUsluguById(int id);
    }
}