using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using api.DTOs;
using System.Text;
using System.Data;
using api.data;
using AutoMapper;

namespace api.Controllers
{
    public class FaktureController : BaseApiController
    {

        private readonly DataContext _context;
        private readonly IFaktureRepository _faktureRepository;
        private readonly IMapper _mapper;
        public FaktureController(DataContext context, IFaktureRepository faktureRepository, IMapper mapper)
        {
            _context = context;
            _faktureRepository = faktureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZaglavljeRacunaDto>>> GetFakture()
        {
            var faktura = await _faktureRepository.GetFaktureAsync();
            
            var fakturaToReturn = _mapper.Map<IEnumerable<ZaglavljeRacunaDto>>(faktura);

            return Ok(fakturaToReturn);
        }

        [HttpGet("{brojracuna}")]
        public async Task<ActionResult<IEnumerable<ZaglavljeRacunaDto>>> GetFakturuByBrojRacuna(int brojracuna)
        {
            var faktura = await _faktureRepository.GetFakturuByBrojRacuna(brojracuna);
            
            var fakturaToReturn = _mapper.Map<ZaglavljeRacunaDto>(faktura);

            return Ok(fakturaToReturn);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ZaglavljeRacunaDto>> AddFakturu(ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            if (await FakturaExists(zaglavljeRacunaDto.Brojracuna)) return BadRequest("Broj racuna vec postoji");
    
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

        private async Task<bool> FakturaExists(int brojRacuna)
        {
            return await _context.ZaglavljeRacuna.AnyAsync(x => x.BrojRacuna == brojRacuna);
        }
    }
}