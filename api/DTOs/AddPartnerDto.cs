using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class AddPartnerDto
    {
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Mjesto { get; set; }
        [Required]
        public int BrojPoste { get; set; }
        [Required]
        public int Mb { get; set; }
        [Required]
        public int Pdv { get; set; }
        [Required]
        public string BankaJedan { get; set; }
        public string BankaDva { get; set; }
        public string BankaTri { get; set; }
        [Required]
        public string Swift { get; set; }
        [Required]
        public string Tip { get; set; }
        [Required]
        public string Drzava { get; set; }
    }
}