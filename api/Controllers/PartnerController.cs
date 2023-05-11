using System.Text;
using api.data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using api.DTOs;
using System;
using api.Interfaces;

namespace api.Controllers
{
    public class PartnerController : BaseApiController
    {
        private readonly DataContext _context;
        public PartnerController(DataContext context)
        {
            _context = context;
        }
        
        [HttpPost("add")]
        public async Task<ActionResult<PartnerDto>> Add(AddPartnerDto addpartnerDto)
        {
            var partner = new Partner
            {
                Naziv = addpartnerDto.Naziv.ToLower(),
                Adresa = addpartnerDto.Adresa.ToLower(),
                Mjesto = addpartnerDto.Mjesto.ToLower(),
                BrojPoste = addpartnerDto.Brojposte,
                Mb = addpartnerDto.Mb,
                Pdv = addpartnerDto.Pdv,
                BankaJedan = addpartnerDto.Bankajedan,
                BankaDva = addpartnerDto.Bankadva,
                BankaTri = addpartnerDto.Bankatri,
                Swift = addpartnerDto.Swift,
                Tip = addpartnerDto.Tip,
                Drzava = addpartnerDto.Drzava
            };
            _context.Partneri.Add(partner);
            await _context.SaveChangesAsync();

            return new PartnerDto
            {
                Naziv = partner.Naziv,
                Adresa = partner.Adresa,
                Mjesto = partner.Mjesto,
                BrojPoste = partner.BrojPoste,
                Mb = partner.Mb,
                Pdv = partner.Pdv,
                BankaJedan = partner.BankaJedan,
                BankaDva = partner.BankaDva,
                BankaTri = partner.BankaTri,
                Swift = partner.Swift,
                Tip = partner.Tip,
                Drzava = partner.Drzava
            };
        }
    }
}