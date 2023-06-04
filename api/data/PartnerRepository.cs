using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using api.DTOs;
using System.Web;
using AutoMapper;

namespace api.data
{

    public class PartnerRepository : IPartnerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PartnerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<PartnerDto> AddPartner(PartnerDto partnerDto)
        {
            var partner = new Partner
            {
                Naziv = partnerDto.Naziv.ToLower(),
                Adresa = partnerDto.Adresa,
                Mjesto = partnerDto.Mjesto,
                BrojPoste = partnerDto.Brojposte,
                Mb = partnerDto.Mb,
                Pdv = partnerDto.Pdv,
                BankaJedan = partnerDto.Bankajedan,
                BankaDva = partnerDto.Bankadva,
                BankaTri = partnerDto.Bankatri,
                Swift = partnerDto.Swift,
                Tip = partnerDto.Tip,
                Drzava = partnerDto.Drzava
            };

            _context.Partneri.Add(partner);
            await _context.SaveChangesAsync();

            return new PartnerDto
            {
                Naziv = partner.Naziv,
                Adresa = partner.Adresa,
                Mjesto = partner.Mjesto,
                Brojposte = partner.BrojPoste,
                Mb = partner.Mb,
                Pdv = partner.Pdv,
                Bankajedan = partner.BankaJedan,
                Bankadva = partner.BankaDva,
                Bankatri = partner.BankaTri,
                Swift = partner.Swift,
                Tip = partner.Tip,
                Drzava = partner.Drzava
            };
        }
        
         public async Task<bool> PartnerUpdate(int id, PartnerDto partnerDto)
        {
            var partner = await _context.Partneri.FindAsync(id);

            if (partner == null)
            {
                return false;
            }

            _mapper.Map(partnerDto, partner);

            _context.Partneri.Update(partner);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> PartnerDelete(int id)
        {
            var partner = await _context.Partneri.FindAsync(id);

            _context.Partneri.Remove(partner);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}