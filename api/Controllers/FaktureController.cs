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

        [HttpGet("zaglavlje")]
        public async Task<ActionResult<IEnumerable<ZaglavljeRacunaDto>>> GetZaglavlja()
        {
            var zaglavlja = await _faktureRepository.GetZaglavljaAsync();
            
            var zaglavljaToReturn = _mapper.Map<IEnumerable<ZaglavljeRacunaDto>>(zaglavlja);

            return Ok(zaglavljaToReturn);
        }

        [HttpGet("stavke")]
        public async Task<ActionResult<IEnumerable<StavkeRacunaDto>>> GetStavke()
        {
            var stavke = await _faktureRepository.GetStavkeAsync();

            var stavkeToReturn = _mapper.Map<IEnumerable<StavkeRacunaDto>>(stavke);

            return Ok(stavkeToReturn);
        }

        [HttpGet("zaglavlje/id")]
        public async Task<ActionResult<IEnumerable<ZaglavljeRacunaDto>>> GetZaglavlje(int id)
        {
            var zaglavlje = await _faktureRepository.GetZaglavljeById(id);
            
            var zaglavljeToReturn = _mapper.Map<ZaglavljeRacunaDto>(zaglavlje);

            return Ok(zaglavljeToReturn);
        }

        [HttpGet("stavke/id")]
        public async Task<ActionResult<IEnumerable<StavkeRacunaDto>>> GetStavku(int id)
        {
            var stavka = await _faktureRepository.GetStavkeById(id);
            
            var stavkaToReturn = _mapper.Map<StavkeRacunaDto>(stavka);

            return Ok(stavkaToReturn);
        }

        [HttpPost("zaglavlje/add")]
        public async Task<ActionResult<ZaglavljeRacunaDto>> AddZaglavlje(ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            if (await ZaglavljeExists(zaglavljeRacunaDto.Brojracuna)) return BadRequest("Broj racuna vec postoji");
    
            var zaglavlje = new ZaglavljeRacuna
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

            _context.ZaglavljeRacuna.Add(zaglavlje);
            await _context.SaveChangesAsync();

            return new ZaglavljeRacunaDto
            {
                Brojracuna = zaglavlje.BrojRacuna,
                Datumisporuke = zaglavlje.DatumIsporuke,
                Datumdokumenta = zaglavlje.DatumDokumenta,
                Datumdospijeca = zaglavlje.DatumDospijeca,
                Opis = zaglavlje.Opis,
                Mjestoizdavanja = zaglavlje.MjestoIzdavanja,
                Datumizdavanja = zaglavlje.DatumIzdavanja,
                Fiskalnibroj = zaglavlje.FiskalniBroj,
                Partnerid = zaglavlje.PartnerId,
                Napomena = zaglavlje.Napomena
            };
        }

        [HttpPost("stavke/add")]
        public async Task<ActionResult<StavkeRacunaDto>> AddStavku(StavkeRacunaDto stavkeRacunaDto)
        {
            var stavka = new StavkeRacuna
            {
                Opis = stavkeRacunaDto.Opis,
                Kolicina = stavkeRacunaDto.Kolicina,
                CijenaDeviza = stavkeRacunaDto.Cijenadeviza,
                FakturnaVrijednost = stavkeRacunaDto.Fakturnavrijednost,
                Rabat = stavkeRacunaDto.Rabat,
                IznosRabata = stavkeRacunaDto.Iznosrabata,
                Pdv = stavkeRacunaDto.Pdv,
                IznosPdv = stavkeRacunaDto.Iznospdv,
                Osnovica = stavkeRacunaDto.Osnovica,
                UkupanIznos = stavkeRacunaDto.Ukupaniznos,
                BrojRacuna = stavkeRacunaDto.Brojracuna
            };

            _context.StavkeRacuna.Add(stavka);
            await _context.SaveChangesAsync();

            return new StavkeRacunaDto
            {
                Opis = stavka.Opis,
                Kolicina = stavka.Kolicina,
                Cijenadeviza = stavka.CijenaDeviza,
                Fakturnavrijednost = stavka.FakturnaVrijednost,
                Rabat = stavka.Rabat,
                Iznosrabata = stavka.IznosRabata,
                Pdv = stavka.Pdv,
                Iznospdv = stavka.IznosPdv,
                Osnovica = stavka.Osnovica,
                Ukupaniznos = stavka.UkupanIznos,
                Brojracuna = stavka.BrojRacuna
            };
        }

        private async Task<bool> ZaglavljeExists(int brojRacuna)
        {
            return await _context.ZaglavljeRacuna.AnyAsync(x => x.BrojRacuna == brojRacuna);
        }
    }
}