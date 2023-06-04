using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Entities;
using api.DTOs;
using System.Web;
using AutoMapper;

namespace api.data
{
    public class UslugeRepository : IUslugeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UslugeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<StavkeRacuna> CalculateVrijednostiAsync(int id)
        {
            var stavkaRacuna = await _context.StavkeRacuna
                .Include(s => s.ZaglavljeRacuna)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (stavkaRacuna == null)
            {
                return null;
            }

            stavkaRacuna.FakturnaVrijednost = stavkaRacuna.Kolicina * stavkaRacuna.CijenaKM;
            if (stavkaRacuna.Rabat > 0) 
            {
                stavkaRacuna.IznosRabata = stavkaRacuna.FakturnaVrijednost / stavkaRacuna.Rabat;
            }
            else
            {
                stavkaRacuna.IznosRabata = 0;
            } 
            stavkaRacuna.Osnovica = stavkaRacuna.FakturnaVrijednost - stavkaRacuna.IznosRabata;
            if (stavkaRacuna.Pdv > 0)
            {
                stavkaRacuna.IznosPdv = stavkaRacuna.Osnovica / stavkaRacuna.Pdv;
            }
            else
            {
                stavkaRacuna.IznosPdv = 0;
            }
            stavkaRacuna.UkupanIznos = stavkaRacuna.Osnovica - stavkaRacuna.IznosPdv;

            await _context.SaveChangesAsync();

            return stavkaRacuna;
        }

        public async Task<bool> UslugaUpdate(int id, UslugaUpdateDto uslugaUpdateDto)
        {
            var usluga = await _context.StavkeRacuna.FindAsync(id);

            if (usluga == null)
            {
                return false;
            }

            _mapper.Map(uslugaUpdateDto, usluga);

            _context.StavkeRacuna.Update(usluga);
            await _context.SaveChangesAsync();

            var updatedUsluga = await CalculateVrijednostiAsync(usluga.Id);

            return true;
        }

        public async Task<StavkeRacunaDto> AddUslugu(StavkeRacunaDto stavkeRacunaDto)
        {
            var usluga = new StavkeRacuna
            {
                Opis = stavkeRacunaDto.Opis,
                Kolicina = stavkeRacunaDto.Kolicina,
                CijenaDeviza = stavkeRacunaDto.Cijenadeviza,
                CijenaKM = stavkeRacunaDto.Cijenakm,
                Rabat = stavkeRacunaDto.Rabat,
                Pdv = stavkeRacunaDto.Pdv,
                BrojRacuna = stavkeRacunaDto.Brojracuna
            };

            _context.StavkeRacuna.Add(usluga);
            await _context.SaveChangesAsync();

            var updatedUsluga = await CalculateVrijednostiAsync(usluga.Id);

            return new StavkeRacunaDto
            {
                Opis = usluga.Opis,
                Kolicina = usluga.Kolicina,
                Cijenadeviza = usluga.CijenaDeviza,
                Cijenakm = usluga.CijenaKM,
                Rabat = usluga.Rabat,
                Pdv = usluga.Pdv,
                Brojracuna = usluga.BrojRacuna
            };
        }

        public async Task<bool> UslugaDelete(int id){

            var usluga = await _context.StavkeRacuna.FindAsync(id);

            _context.StavkeRacuna.Remove(usluga);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}