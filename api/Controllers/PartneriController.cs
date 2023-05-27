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

        [HttpGet("{name}")]
        public async Task<ActionResult<PartnerDto>> GetUser(string name)
        {
            var partner = await _partnerRepository.GetPartnerByNameAsync(name);

            return _mapper.Map<PartnerDto>(partner);
        }

        [HttpPost("add")]
        public async Task<ActionResult<PartnerDto>> AddPartner(PartnerDto partnerDto)
        {
            if (await PartnerExists(partnerDto.Naziv)) return BadRequest("Name already taken!");

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

        private async Task<bool> PartnerExists(string name)
        {
            return await _context.Partneri.AnyAsync(x => x.Naziv == name.ToLower());
        }
        
    }
}