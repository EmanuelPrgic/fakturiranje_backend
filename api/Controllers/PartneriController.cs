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
    public class PartneriController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IPartnerRepository _partnerRepository;
        private readonly IMapper _mapper;
        public PartneriController(DataContext context, IPartnerRepository partnerRepository, IMapper mapper)
        {
            _partnerRepository = partnerRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerDto>>> GetPartners()
        {
            var partners = await _partnerRepository.GetPartnersAsync();

            var partnersToReturn = _mapper.Map<IEnumerable<PartnerDto>>(partners);

            return Ok(partnersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerDto>> GetUser(int id)
        {
            var partner = await _partnerRepository.GetPartnerByIdAsync(id);

            return _mapper.Map<PartnerDto>(partner);
        }

        [HttpPost("add")]
        public async Task<ActionResult<PartnerDto>> AddPartner(PartnerDto partnerDto)
        {
            var partner = await _partnerRepository.AddPartner(partnerDto);

            return Ok(partner);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> PartnerUpdate(int id, PartnerDto partnerDto)
        {
            var result = await _partnerRepository.PartnerUpdate(id, partnerDto);

            return NoContent();
        }     

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> PartnerDelete(int id)
        {
            var result = await _partnerRepository.PartnerDelete(id);

            return NoContent();
        } 
    }
}