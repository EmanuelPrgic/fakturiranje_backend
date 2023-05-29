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
    public class UslugeRepository : IUslugeRepository
    {
        private readonly DataContext _context;

        public UslugeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<StavkeRacuna> GetUsluguById(int id)
        {
            return await _context.StavkeRacuna.FindAsync(id);
        }

        public async Task<IEnumerable<StavkeRacuna>> GetUslugeAsync()
        {
            return await _context.StavkeRacuna.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UslugaUpdate(StavkeRacuna stavkeRacuna)
        {
            _context.Entry(stavkeRacuna).State = EntityState.Modified;
        }
    }
}