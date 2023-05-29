using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Entities;

namespace api.data
{
    public class FaktureRepository : IFaktureRepository
    {
        private readonly DataContext _context;
        public FaktureRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ZaglavljeRacuna> GetFakturuByBrojRacuna(int brojracuna)
        {
            return await _context.ZaglavljeRacuna.FindAsync(brojracuna);
        }

        public async Task<IEnumerable<ZaglavljeRacuna>> GetFaktureAsync()
        {
            return await _context.ZaglavljeRacuna.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void FakturaUpdate(ZaglavljeRacuna zaglavljeRacuna)
        {
            _context.Entry(zaglavljeRacuna).State = EntityState.Modified;
        }
    }
}