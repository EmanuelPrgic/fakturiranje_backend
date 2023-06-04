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

        private readonly IFaktureRepository _faktureRepository;
        private readonly IMapper _mapper;
        public FaktureController(IFaktureRepository faktureRepository, IMapper mapper)
        {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ZaglavljeRacunaDto>>> GetFakturuById(int id)
        {
            var faktura = await _faktureRepository.GetFakturuById(id);
            
            var fakturaToReturn = _mapper.Map<ZaglavljeRacunaDto>(faktura);

            return Ok(fakturaToReturn);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ZaglavljeRacunaDto>> AddFakturu(ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            var faktura = await _faktureRepository.AddFakturu(zaglavljeRacunaDto);

            return Ok(faktura);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> FakturaEdit(int id, ZaglavljeRacunaDto zaglavljeRacunaDto)
        {
            var faktura = await _faktureRepository.FakturaUpdate(id, zaglavljeRacunaDto);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> FakturaDelete(int id)
        {
            var faktura = await _faktureRepository.FakturaDelete(id);

            return NoContent();
        }
    }
}