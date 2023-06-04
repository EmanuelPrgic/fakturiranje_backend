using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.Entities;
using api.DTOs;
using AutoMapper;

namespace api.data
{
    public class FaktureRepository : IFaktureRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public FaktureRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ZaglavljeRacuna> GetFakturuByBrojRacuna(int brojracuna)
        {
            return await _context.ZaglavljeRacuna.FindAsync(brojracuna);
        }

        public async Task<ZaglavljeRacuna> GetFakturuById(int id)
        {
            return await _context.ZaglavljeRacuna.FindAsync(id);
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

        public async Task<ZaglavljeRacunaDto> AddFakturu(ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            var faktura = new ZaglavljeRacuna
            {
                BrojRacuna = zaglavljeRacunaDto.Brojracuna,
                DatumIsporuke = zaglavljeRacunaDto.Datumisporuke,
                DatumDokumenta = zaglavljeRacunaDto.Datumdokumenta,
                DatumDospijeca = zaglavljeRacunaDto.Datumdospijeca,
                Opis = zaglavljeRacunaDto.Opis,
                MjestoIzdavanja = zaglavljeRacunaDto.Mjestoizdavanja,
                DatumIzdavanja = zaglavljeRacunaDto.Datumizdavanja,
                FiskalniBroj = zaglavljeRacunaDto.Fiskalnibroj,
                PartnerId = zaglavljeRacunaDto.Partnerid,
                Napomena = zaglavljeRacunaDto.Napomena
            };

            _context.ZaglavljeRacuna.Add(faktura);
            await _context.SaveChangesAsync();

            return new ZaglavljeRacunaDto
            {
                Brojracuna = faktura.BrojRacuna,
                Datumisporuke = faktura.DatumIsporuke,
                Datumdokumenta = faktura.DatumDokumenta,
                Datumdospijeca = faktura.DatumDospijeca,
                Opis = faktura.Opis,
                Mjestoizdavanja = faktura.MjestoIzdavanja,
                Datumizdavanja = faktura.DatumIzdavanja,
                Fiskalnibroj = faktura.FiskalniBroj,
                Partnerid = faktura.PartnerId,
                Napomena = faktura.Napomena
            };
        }

        public async Task<bool> FakturaUpdate(int id, ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            var faktura = await _context.ZaglavljeRacuna.FindAsync(id);

            if (faktura == null)
            {
                return false;
            }

            _mapper.Map(zaglavljeRacunaDto, faktura);

            _context.ZaglavljeRacuna.Update(faktura);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FakturaDelete(int id)
        {
            var faktura = await _context.ZaglavljeRacuna.FindAsync(id);

            _context.ZaglavljeRacuna.Remove(faktura);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}