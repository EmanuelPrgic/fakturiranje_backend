using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.DTOs;

namespace api.Interfaces
{
    public interface IPartnerRepository
    {
        void Update(Partner partner);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Partner>> GetPartnersAsync();
        Task<Partner> GetPartnerByIdAsync(int id);
        Task<Partner> GetPartnerByNameAsync(string name);
    }
}