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
        private readonly IUslugeRepository _uslugeRepository;        
        private readonly IMapper _mapper;
        public UslugeController(IUslugeRepository uslugeRepository, IMapper mapper)
        {
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
        
        [HttpPost("calculate/{id}")]
        public async Task <ActionResult<StavkeRacuna>> CalculateVrijednostiAsync(int id)
        {
            var stavka = await _uslugeRepository.CalculateVrijednostiAsync(id);

            return Ok(stavka);
        }

        [HttpPost("add")]
        public async Task<ActionResult<StavkeRacunaDto>> AddUslugu(StavkeRacunaDto stavkeRacunaDto)
        {
            
            var usluga = await _uslugeRepository.AddUslugu(stavkeRacunaDto);

            return Ok(usluga);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> UslugaUpdate(int id, UslugaUpdateDto uslugaUpdateDto)
        {
            var result = await _uslugeRepository.UslugaUpdate(id, uslugaUpdateDto);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> UslugaDelete(int id)
        {
            await _uslugeRepository.UslugaDelete(id);

            return NoContent();
        }

    }
}