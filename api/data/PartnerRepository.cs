using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.data
{

    public class PartnerRepository : IPartnerRepository
    {
        private readonly DataContext _context;
        public PartnerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Partner> GetPartnerByIdAsync(int id)
        {
            return await _context.Partneri.FindAsync(id);
        }

        public async Task<Partner> GetPartnerByNameAsync(string name)
        {
            return await _context.Partneri.SingleOrDefaultAsync(x => x.Naziv == name);
        }

        public async Task<IEnumerable<Partner>> GetPartnersAsync()
        {
            return await _context.Partneri.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Partner partner)
        {
            _context.Entry(partner).State = EntityState.Modified;
        }
    }
}