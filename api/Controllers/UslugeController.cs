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
    public class UslugeController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IUslugeRepository _uslugeRepository;
        
        private readonly IMapper _mapper;
        public UslugeController(DataContext context, IUslugeRepository uslugeRepository, IMapper mapper)
        {
            _context = context;
            _uslugeRepository = uslugeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StavkeRacunaDto>>> GetStavke()
        {
            var usluga = await _uslugeRepository.GetUslugeAsync();
            var uslugaToReturn = _mapper.Map<IEnumerable<StavkeRacunaDto>>(usluga);
            return Ok(uslugaToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StavkeRacunaDto>>> GetUsluguById(int id)
        {
            var usluga = await _uslugeRepository.GetUsluguById(id);
            var uslugaToReturn = _mapper.Map<StavkeRacunaDto>(usluga);
            return Ok(uslugaToReturn);
        }
        
        [HttpPost("add")]
        public async Task<ActionResult<StavkeRacunaDto>> AddUslugu(StavkeRacunaDto stavkeRacunaDto)
        {
            if (await UslugaExists(stavkeRacunaDto.Id)) return BadRequest("Ovaj ID vec postoji!");

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

        private async Task<bool> UslugaExists(int id)
        {
            return await _context.StavkeRacuna.AnyAsync(x => x.Id == id);
        }
    }
}