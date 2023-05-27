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

        public async Task<ZaglavljeRacuna> GetZaglavljeById(int id)
        {
            return await _context.ZaglavljeRacuna.FindAsync(id);
        }

        public async Task<StavkeRacuna> GetStavkeById(int id)
        {
            return await _context.StavkeRacuna.FindAsync(id);
        }

        public async Task<ZaglavljeRacuna> GetZaglavljeByBrojRacuna(int brojRacuna)
        {
            return await _context.ZaglavljeRacuna.FindAsync(brojRacuna);
        }

        public async Task<IEnumerable<ZaglavljeRacuna>> GetZaglavljaAsync()
        {
            return await _context.ZaglavljeRacuna.ToListAsync();
        }

        public async Task<IEnumerable<StavkeRacuna>> GetStavkeAsync()
        {
            return await _context.StavkeRacuna.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void ZaglavljeUpdate(ZaglavljeRacuna zaglavljeRacuna)
        {
            _context.Entry(zaglavljeRacuna).State = EntityState.Modified;
        }

        public void StavkeUpdate(StavkeRacuna stavkeRacuna)
        {
            _context.Entry(stavkeRacuna).State = EntityState.Modified;
        }
    }
}